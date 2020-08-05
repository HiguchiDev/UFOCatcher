using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    private Rigidbody rb;
    public bool isOpenComp;
    public bool isCloseComp;
    private LeftUFO ufo;
    private float initZ;
    private float ROTATE_SPEED = 25.0f;
    private const float OPEN_ANGLE = 300.0f;
    private const float STOP_ANGLE = OPEN_ANGLE - 1.0f;
    public bool isFalled;
    private int closeWaitCount = 0;
    private const int CLOSE_WAIT_MAX = 100;
    private int closeActionCount = 0;
    private const int CLOSE_ACTION_MAX = 100;

    // Start is called before the first frame update
    void Start()
    {
        isOpenComp = false;
        isCloseComp = false;
        transform.Rotate(new Vector3(0,0,-0.001f));
        this.ufo = this.gameObject.GetComponent<LeftUFO>();
        this.initZ = transform.localEulerAngles.z;
        this.rb = GetComponent<Rigidbody>();
        rb.AddTorque(0, 0, ROTATE_SPEED, ForceMode.Force);
        this.isFalled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.isOpenComp == false) {
            rb.AddTorque(0, 0, ROTATE_SPEED, ForceMode.Force);
            
            if(transform.localEulerAngles.z <= OPEN_ANGLE) {
                this.isOpenComp = true;
                this.rb.constraints = RigidbodyConstraints.FreezeRotation;
                this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, STOP_ANGLE + 1.0f);
            }
        }
        else if (this.isCloseComp == false) {
            this.rb.constraints = RigidbodyConstraints.None;

            if(this.transform.localEulerAngles.z <= STOP_ANGLE) {
                this.isFalled = true;
            }

            if(this.isFalled) {
                if(this.closeWaitCount < CLOSE_WAIT_MAX) {
                    this.closeWaitCount++;
                } else if(this.closeActionCount < CLOSE_ACTION_MAX /*&& this.initZ <= transform.localEulerAngles.z*/) {
                    this.closeActionCount++;
                    rb.AddTorque(0, 0, -ROTATE_SPEED, ForceMode.Force);
                } else {
                    this.isCloseComp = true;

                }
            }
        }

        if(this.isCloseComp && this.isFalled) {
            rb.AddTorque(0, 0, -ROTATE_SPEED, ForceMode.Force);
        }

        Debug.Log("init z : " + this.initZ);
        Debug.Log("z : " + transform.localEulerAngles.z);

        //物理エンジンを無視するために角度を補正
        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = transform.localEulerAngles;
        worldAngle.x = 0.0f; // ワールド座標を基準に、x軸を軸にした回転を10度に変更
        worldAngle.y = 180.0f; // ワールド座標を基準に、y軸を軸にした回転を10度に変更
        //worldAngle.z = 50.0f; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
        transform.eulerAngles = worldAngle; // 回転角度を設定
    }

}
