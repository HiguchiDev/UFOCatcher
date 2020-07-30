﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmCloser : UFOAction
{
    private Rigidbody rb;
    private const float CLOSE_SPEED = 1000.0f;
    private const float CLOSE_ANGLE = 358.0f;
    public bool isEnd = false;
    private int waitCount = 0;
    private const int WAIT_MAX = 300;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd == false) {
            //アームクローズ
            rb.AddTorque(0, 0, CLOSE_SPEED, ForceMode.Force);
            notFreezeRotation();
        }
        else {
            //加速オフ
            rb.angularVelocity = Vector3.zero;

            //待機時間まではアーム固定
            if(waitCount <= WAIT_MAX){
                waitCount++;
                freezeRotation();
            }
            //アーム開放
            else{
                notFreezeRotation();
            }

        }
     
        //クローズ角度を超えたら or 速度が速くて一周したら（z <= 100.0f）
        if(isEnd == false &&
            (transform.localEulerAngles.z >= CLOSE_ANGLE || transform.localEulerAngles.z <= 100.0f)) {
            isEnd = true;
            rb.angularVelocity = Vector3.zero;
        }
    }

    //  当たったら止める
    void OnCollisionStay(Collision collision)
    {
        isEnd = true;
        rb.angularVelocity = Vector3.zero;
        //Debug.Log("collision object name  : " + collision.gameObject.name);
    }

    void OnCollisionExit(Collision collision)
    {
        isEnd = false;
        //Debug.Log("collision exit");

    }

    private void notFreezeRotation() {
        this.rb.constraints = RigidbodyConstraints.None;
    }

    private void freezeRotation() {
        this.rb.constraints = RigidbodyConstraints.FreezeRotation;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
    }

    private void fixedPosition() {
        this.rb.constraints = RigidbodyConstraints.FreezeRotation;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        this.rb.constraints = RigidbodyConstraints.None;
    }

    public override bool isActionEnd() {
        if(waitCount <= WAIT_MAX){
            return false;
        }
        
        return isEnd;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        return null;
    }

    public override void after() {
        rb.angularVelocity = Vector3.zero;
    }
}