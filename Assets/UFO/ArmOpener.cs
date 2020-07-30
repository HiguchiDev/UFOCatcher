using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmOpener : UFOAction
{

    RightArmOpener rightArmOpener;
    LeftArmOpener leftArmOpener;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        rightArm.AddComponent<RightArmOpener>();
        rightArmOpener = rightArm.GetComponent<RightArmOpener>();

        leftArm.AddComponent<LeftArmOpener>();
        leftArmOpener = leftArm.GetComponent<LeftArmOpener>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool isActionEnd() {
        return rightArmOpener.isActionEnd() || leftArmOpener.isActionEnd();
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        rightArmOpener.exchangeNextScript(obj);
        leftArmOpener.exchangeNextScript(obj);

        obj.AddComponent<UFOBodyFaller>();
        
        return obj.GetComponent<UFOBodyFaller>();
    }

    public override void after() {
        rightArmOpener.after();
        leftArmOpener.after();
    }

}
