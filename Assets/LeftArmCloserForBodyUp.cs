using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmCloserForBodyUp : UFOAction
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool isActionEnd() {
        //Debug.Log("[" + nameof(RightArmCloser) + "] z angle : " + transform.localEulerAngles.z + ", open z angle : " + CLOSE_ANGLE);
        return false;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        return null;
    }

    public override void after() {
        //fixedPosition();
    }

}
