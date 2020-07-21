using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBodyUpper : UFOAction
{
    private const float Y_SPPED = 0.025f;
    //private const float STOP_ANGLE = 300.0f - 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, Y_SPPED, 0);
        //Debug.Log("[" + nameof(UFOBodyUpper) + "] y position : " + this.transform.position);
    }

    public override bool isActionEnd() {
        return false;
    }

    public override UFOAction exchangeNextScript(GameObject obj){
        Destroy(this);
        obj.AddComponent<UFOWait>();
        return obj.GetComponent<UFOWait>();
    }

    
}
