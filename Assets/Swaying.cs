using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaying : MonoBehaviour
{
    float rotateSpeed = 0.1f;
    const float ROTATE_MAX = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        if(this.transform.localEulerAngles.z <= ROTATE_MAX){
            Vector3 position = this.transform.position;
            position.x += rotateSpeed * 0.27f;
            this.transform.position = position;

            Vector3 rotate = this.transform.localEulerAngles;
            rotate.z += rotateSpeed;
            this.transform.localEulerAngles = rotate;
        }
        */
    }
}
