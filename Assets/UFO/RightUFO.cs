using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightUFO : MonoBehaviour
{
    private float initialX;
    private float initialZ;
    private GameObject ufoBody;

    // Start is called before the first frame update
    void Start()
    {
        this.initialX = transform.position.x;
        this.initialZ = transform.position.z;
        this.ufoBody = GameObject.Find("UFOBody");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(this.ufoBody.transform.position.x - 2.0f, this.ufoBody.transform.position.y + 0.25f, this.ufoBody.transform.position.z);
        fixedAngleXY();
    }

    private void fixedAngleXY() {
        Vector3 worldAngle = transform.localEulerAngles;
        worldAngle.x = 0.0f; // ワールド座標を基準に、x軸を軸にした回転を10度に変更
        worldAngle.y = 0.0f; // ワールド座標を基準に、y軸を軸にした回転を10度に変更
        //worldAngle.z = 50.0f; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
        transform.eulerAngles = worldAngle; // 回転角度を設定
    }
}
