using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class vezier : MonoBehaviour
{
    Vector3 initPos;
    Vector3 upPos;
    Vector3[] path;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = this.transform.position;

        initPos = new Vector3(position.x, position.y, position.z);
        upPos = new Vector3(position.x, position.y + 20, position.z);

		path = new Vector3[]{
			initPos,
			upPos,
			initPos,
		};
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            transform.DOPath(path, 1.0f, PathType.CatmullRom);
        }
    }
}
