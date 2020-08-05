using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBodyFaller : UFOAction
{
    private const float STOP_ANGLE = 300.0f - 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += new Vector3(0, -GameParameters.UFO_BODY_FALL_SPEED, 0);
        //Debug.Log("[" + nameof(UFOBodyFaller) + "] y position : " + this.transform.position);
    }

    public override bool isActionEnd() {
        /*if( rightArm.transform.localEulerAngles.z <= STOP_ANGLE || leftArm.transform.localEulerAngles.z <= STOP_ANGLE || ufoBody.GetComponent<UFOBody>().isCollision ){
            Debug.Log("right : " + rightArm.transform.localEulerAngles.z);
            Debug.Log("left : " + leftArm.transform.localEulerAngles.z);
            Debug.Log("isCollision : " + ufoBody.GetComponent<UFOBody>().isCollision);
        }*/
        return rightArm.transform.localEulerAngles.z <= STOP_ANGLE || leftArm.transform.localEulerAngles.z <= STOP_ANGLE || ufoBody.GetComponent<UFOBody>().isCollision;
    }

    public override UFOAction exchangeNextScript(GameObject obj){
        Destroy(this);
        obj.AddComponent<ArmCloser>();
        return obj.GetComponent<ArmCloser>();
    }
}
