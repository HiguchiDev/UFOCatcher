using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huriko_Test : MonoBehaviour
{
    GameObject a;
    float initY;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("TestCircle");    
        initY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;
        position.x = a.transform.position.x;
        position.y = initY;
        position.z = a.transform.position.z;

        this.transform.position = position;
    }
}
