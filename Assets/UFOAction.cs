using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UFOAction : MonoBehaviour
{
    protected GameObject leftArm;
    protected GameObject rightArm;
    protected GameObject ufoBody;

    // Start is called before the first frame update
    public void Start()
    {
        leftArm = GameObject.Find("LeftArm");
        rightArm = GameObject.Find("RightArm");
        ufoBody = GameObject.Find("UFOBody");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public abstract bool isActionEnd();

    public abstract UFOAction exchangeNextScript(GameObject obj);

    public virtual void after() {

    }
}
