using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOReturnMover : UFOAction
{
    private float initX, initZ;
    private float speed = GameParameters.UFO_BODY_MOVE_SPEED;

    // Start is called before the first frame update
    void Start()
    {
        initX = 4.5f;
        initZ = -10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //base.Update();

        Vector3 position = this.transform.position;

        if(position.x <= initX){
            position.x += speed;
        //    Debug.Log("move x");
        }

        //Debug.Log("x : " + position.x + ", initX : " + initX);

        if(position.z >= initZ){
            position.z -= speed;
        //    Debug.Log("move z");
        }

        //Debug.Log("z : " + position.z + ", initZ : " + initZ);

        this.transform.position = position;
    }

    public override bool isActionEnd() {
        return this.transform.position.x >= initX && this.transform.position.z <= initZ;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        obj.AddComponent<UFOWait>();
        return obj.GetComponent<UFOWait>();
    }
}
