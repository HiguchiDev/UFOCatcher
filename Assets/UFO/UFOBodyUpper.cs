using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBodyUpper : UFOAction
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
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
        Destroy(this);
        obj.AddComponent<UFOReturnMover>();
        return obj.GetComponent<UFOReturnMover>();
    }
}
