using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOWait : UFOAction
{

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        leftArm.AddComponent<TempWait>();
        rightArm.AddComponent<TempWait>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public override bool isActionEnd() {
        return false;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        return null;
    }
}
