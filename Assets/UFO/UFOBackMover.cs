using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBackMover : UFOMover
{
    // Start is called before the first frame update
    void Start()
    {
        speedZ = 0.025f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override UFOAction exchangeNextScript(GameObject obj){
        Destroy(this);
        obj.AddComponent<UFOWait>();
        return obj.GetComponent<UFOWait>();
    }
}
