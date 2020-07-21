using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmCloserForBodyUp : UFOAction
{
    private Rigidbody rb;
    private const float CLOSE_SPEED = 50.0f;
    private const float CLOSE_ANGLE = 358.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActionEnd() == false) {
            rb.AddTorque(0, 0, CLOSE_SPEED, ForceMode.Force);
        }
//        Debug.Log("[" + nameof(RightArmCloser) + "] z angle : " + transform.localEulerAngles.z + ", open z angle : " + CLOSE_ANGLE);
    }

    public override bool isActionEnd() {
        //Debug.Log("[" + nameof(RightArmCloser) + "] z angle : " + transform.localEulerAngles.z + ", open z angle : " + CLOSE_ANGLE);
        return transform.localEulerAngles.z >= CLOSE_ANGLE;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        return null;
    }

    public override void after() {
        //fixedPosition();
    }
}
