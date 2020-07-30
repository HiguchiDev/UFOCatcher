using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Camera : MonoBehaviour {
 
    private GameObject frontCamera;      //メインカメラ格納用
    private GameObject sideCamera;       //サブカメラ格納用 
 
 
    //呼び出し時に実行される関数
    void Start () {
        //メインカメラとサブカメラをそれぞれ取得
        frontCamera = GameObject.Find("MainCamera");
        sideCamera = GameObject.Find("SideCamera");
 
        //サブカメラを非アクティブにする
        sideCamera.SetActive(false); 
	}
	
 
	//単位時間ごとに実行される関数
	void Update () {
		//スペースキーが押されている間、サブカメラをアクティブにする
        if(Input.GetKeyDown(KeyCode.Z)){
            if(frontCamera.activeSelf){
                //サブカメラをアクティブに設定
                frontCamera.SetActive(false);
                sideCamera.SetActive(true);
                Debug.Log("main camera active");
            }else{
                //メインカメラをアクティブに設定
                frontCamera.SetActive(true);
                sideCamera.SetActive(false);
                Debug.Log("side camera active");
            }
        }

        if (Input.GetKey(KeyCode.Escape)){
            UnityEngine.Application.Quit();
        }
              
	}
}