using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBodyUpper : UFOAction
{

    RightArmCloserUpper rightArmCloser;
    LeftArmCloserUpper leftArmCloser;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();


        rightArm.AddComponent<RightArmCloserUpper>();
        rightArmCloser = rightArm.GetComponent<RightArmCloserUpper>();

        leftArm.AddComponent<LeftArmCloserUpper>();
        leftArmCloser = leftArm.GetComponent<LeftArmCloserUpper>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += new Vector3(0, GameParameters.UFO_BODY_UP_SPEED, 0);
        //Debug.Log("[" + nameof(UFOBodyUpper) + "] y position : " + this.transform.position);

        //leftArm.GetComponent<Rigidbody>().mass-=GameParameters.ARM_MASS_DEC;
        //rightArm.GetComponent<Rigidbody>().mass-=GameParameters.ARM_MASS_DEC;
        
    }

    public override bool isActionEnd() {
        return this.transform.position.y >= GameParameters.UFO_INIT_Y;
    }

    public override UFOAction exchangeNextScript(GameObject obj){
        rightArmCloser.exchangeNextScript(obj);
        leftArmCloser.exchangeNextScript(obj);
        Destroy(this);
        obj.AddComponent<UFOReturnMover>();
        return obj.GetComponent<UFOReturnMover>();
    }
}
