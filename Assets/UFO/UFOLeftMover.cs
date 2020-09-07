using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOLeftMover : UFOMover
{
    private UFOStopper stopper;
    
    // Start is called before the first frame update
    void Start()
    {
        stopper = GameObject.Find("LeftStopper").GetComponent<UFOStopper>();
        speedX = -GameParameters.UFO_BODY_MOVE_SPEED;
        GameParameters.score += 100;
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if(stopper.isWallCollision == true){
            this.isEnd = true;
        }
    }

    public override UFOAction exchangeNextScript(GameObject obj){
        Destroy(this);
        obj.AddComponent<UFOBackMoveWait>();
        return obj.GetComponent<UFOBackMoveWait>();
    }
}
