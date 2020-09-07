using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJudgementer : MonoBehaviour
{

    public bool isGet = false;
    private GetMessage getMessage;

    // Start is called before the first frame update
    void Start()
    {
        this.getMessage = GameObject.Find("GetMessage").GetComponent<GetMessage>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(isGet && this.getMessage.actioned == false){
            this.getMessage.action();
        }
        
    }

    private void OnCollisionStay(Collision collision){
 
        this.isGet = true;
    }
}
