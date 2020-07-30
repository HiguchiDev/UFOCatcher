using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UFOMover : UFOAction
{
    private bool isEnd = false;
    protected float speedX = 0.0f;
    protected float speedZ = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void  Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + speedX, this.transform.position.y, this.transform.position.z + speedZ);
    }

    public void stop(){
        isEnd = true;
    }

    public override bool isActionEnd(){
        return isEnd;
    }
}
