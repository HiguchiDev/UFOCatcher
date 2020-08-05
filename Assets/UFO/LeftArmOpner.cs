using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmOpener : UFOAction
{
    private Rigidbody rb;
    private const float OPEN_ANGLE = 300.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, 359.9f);
        //Debug.Log("[" + nameof(LeftArmOpener) + "] Initialze! z angle : " + transform.localEulerAngles.z + ", open z angle : " + OPEN_ANGLE);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(0, 0, GameParameters.ARM_OPEN_SPPED, ForceMode.Force);
        //Debug.Log("[" + nameof(LeftArmOpener) + "] z angle : " + transform.localEulerAngles.z + ", open z angle : " + OPEN_ANGLE);
    }

    private void fixedPosition() {
        this.rb.constraints = RigidbodyConstraints.FreezeRotation;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, OPEN_ANGLE);
        this.rb.constraints = RigidbodyConstraints.None;
        //Debug.Log("[" + nameof(LeftArmOpener) + "] z angle : " + transform.localEulerAngles.z + ", open z angle : " + OPEN_ANGLE);
    }

    public override bool isActionEnd() {
        //Debug.Log("[" + nameof(LeftArmOpener) + "] z angle : " + transform.localEulerAngles.z + ", open z angle : " + OPEN_ANGLE);
        return transform.localEulerAngles.z <= OPEN_ANGLE;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        return null;
    }

    public override void after() {
        fixedPosition();
    }
}
