using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWait : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        this.rb.constraints = RigidbodyConstraints.FreezeRotation;
        this.rb.constraints = RigidbodyConstraints.FreezePosition;
        //fixedAngleXY();
    }

    private void fixedAngleXY() {
        Vector3 worldAngle = transform.localEulerAngles;
        worldAngle.x = 0.0f; // ワールド座標を基準に、x軸を軸にした回転を10度に変更
        worldAngle.y = 0.0f; // ワールド座標を基準に、y軸を軸にした回転を10度に変更
        //worldAngle.z = 50.0f; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
        transform.eulerAngles = worldAngle; // 回転角度を設定
    }
}
