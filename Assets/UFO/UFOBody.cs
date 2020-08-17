using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBody : MonoBehaviour
{
    public bool isCollision = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name != "Prim.00000000"){
            isCollision = true;
        }
        Debug.Log("OtherName : " + other.gameObject.name);
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.name != "Prim.00000000"){
            isCollision = false;
        }
    }
}
