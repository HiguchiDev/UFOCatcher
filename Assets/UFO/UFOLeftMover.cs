using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOLeftMover : UFOMover
{
    // Start is called before the first frame update
    void Start()
    {
        speedX = -0.025f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override UFOAction exchangeNextScript(GameObject obj){
        Destroy(this);
        obj.AddComponent<UFOBackMoveWait>();
        return obj.GetComponent<UFOBackMoveWait>();
    }
}
