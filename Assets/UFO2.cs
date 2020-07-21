using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO2 : MonoBehaviour
{
    private Rigidbody rb;
    private float initialX;
    private float initialZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector3 (0.0f,-4000.0f,0.0f));

        this.initialX = transform.position.x;
        this.initialZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(this.initialX, transform.position.y, this.initialZ);

        
    }
}
