using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCloser : UFOAction
{
   RightArmCloser rightArmCloser;
   LeftArmCloser leftArmCloser;
   private int waitCount = 0;
   private const int WAIT_MAX = 200;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        rightArm.AddComponent<RightArmCloser>();
        rightArmCloser = rightArm.GetComponent<RightArmCloser>();

        leftArm.AddComponent<LeftArmCloser>();
        leftArmCloser = leftArm.GetComponent<LeftArmCloser>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool isActionEnd() {
        return rightArmCloser.isActionEnd() || leftArmCloser.isActionEnd() || ++waitCount >= WAIT_MAX;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        
        
        if(waitCount >= WAIT_MAX) {
            //rightArmCloser.exchangeNextScript(obj);
            //leftArmCloser.exchangeNextScript(obj);
        }
        obj.AddComponent<UFOBodyUpper>();
        
        return obj.GetComponent<UFOBodyUpper>();
    }

    public override void after() {
        if(waitCount >= WAIT_MAX) {
            //rightArmCloser.after();
            //leftArmCloser.after();
        }
    }

}
