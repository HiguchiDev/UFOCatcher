using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmCloser : UFOAction
{
    private Rigidbody rb;
    private const float CLOSE_ANGLE = 358.0f;
    public bool isEnd = false;
    public int waitCount = 0;
    private GameObject obj_debug;
    private Vector3 beforeRotate;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.obj_debug = GameObject.Find("RightArmObj");

        //beforeRotate = transform.localEulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 after = transform.localEulerAngles;

        if (isEnd == false) {
            //アームクローズ
            rb.AddTorque(0, 0, GameParameters.ARM_CLOSE_SPPED, ForceMode.Force);
            notFreezeRotation();
           // obj_debug.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else {

            /*
            if (beforeRotate.z > after.z)
            {
                rb.AddTorque(0, 0, GameParameters.ARM_CLOSE_SPPED * 2, ForceMode.Force);
                obj_debug.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                //加速オフ
                rb.angularVelocity = Vector3.zero;
                obj_debug.GetComponent<Renderer>().material.color = Color.gray;
            }
            */
            //待機時間まではアーム固定
            if (waitCount <= GameParameters.CLOSE_WAIT_MAX){
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


        //beforeRotate = transform.localEulerAngles;
    }

    //  当たったら止める
    void OnCollisionStay(Collision collision)
    {
        isEnd = true;
        //rb.angularVelocity = Vector3.zero;
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

    public override bool isActionEnd() {
        if(waitCount <= GameParameters.CLOSE_WAIT_MAX){
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
