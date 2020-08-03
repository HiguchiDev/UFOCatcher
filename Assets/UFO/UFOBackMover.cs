using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBackMover : UFOMover
{
    // Start is called before the first frame update
    void Start()
    {
        speedZ = GameParameters.UFO_BODY_MOVE_SPEED;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override UFOAction exchangeNextScript(GameObject obj){
        Destroy(this);

        destroyUFOActions(rightArm);
        destroyUFOActions(leftArm);

        obj.AddComponent<ArmOpener>();
        return obj.GetComponent<ArmOpener>();
    }

    private void destroyUFOActions(GameObject obj){
        UFOAction[] ufoActions = obj.GetComponents<UFOAction> ();

        foreach (UFOAction action in ufoActions) {
            Destroy(action);
        }
    }
}
