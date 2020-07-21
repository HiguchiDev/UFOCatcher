using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{

    private LeftArm leftArm;
    private RightArmOpener rightArm;
    private float ySpeed;
    private float initY;

    // Start is called before the first frame update
    void Start()
    {
        this.leftArm = GameObject.Find("LeftArm").GetComponent<LeftArm>();
        this.rightArm = GameObject.Find("RightArm").GetComponent<RightArmOpener>();
        this.ySpeed = 0.01f;
        this.initY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
/*
        if(this.isFalledAndClose()) {
            Debug.Log("this.transform.position.y" + this.transform.position.y);
            Debug.Log("this.initY" + this.initY);
            if(this.transform.position.y <= this.initY ) {
                this.transform.position += new Vector3(0, ySpeed, 0);
            }
        } else if(this.isFalled()) {

        } else if(this.isOpenComp()) {
            this.transform.position += new Vector3(0, -ySpeed, 0);
        }

*/
        
    }
/*
    private bool isFalledAndClose(){
        return (this.leftArm.isFalled || this.rightArm.isFalled) &&
                this.leftArm.isCloseComp;
    }

    private bool isFalled(){
        return this.leftArm.isFalled || this.rightArm.isFalled;
    }

    private bool isOpenComp(){
        return this.leftArm.isOpenComp && this.rightArm.isOpenComp;
    }*/
}
