using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmCloserUpper : UFOAction
{
    private Rigidbody rb;
    private const float CLOSE_ANGLE = 358.0f;
    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isEnd == false) {
            //アームクローズ
            rb.AddTorque(0, 0, -GameParameters.ARM_CLOSE_SPPED, ForceMode.Force);
            notFreezeRotation();
            //obj_debug.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            freezeRotation();
        }

        //クローズ角度を超えたら or 速度が速くて一周したら（z <= 100.0f）
        if (isEnd == false &&
            (transform.localEulerAngles.z >= CLOSE_ANGLE || transform.localEulerAngles.z <= 100.0f)) {
            isEnd = true;
            rb.angularVelocity = Vector3.zero;
        }

    }

    private void notFreezeRotation() {
        this.rb.constraints = RigidbodyConstraints.None;
    }

    private void freezeRotation() {
        this.rb.constraints = RigidbodyConstraints.FreezeRotation;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
    }

    public override bool isActionEnd() {   
        return isEnd;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        return null;
    }

}
