using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GetMessage : MonoBehaviour
{
    private Vector3[] path;
    private RectTransform rectTransform;
    private Vector3 initPos;
    private Vector3 upPos;
    private Vector3 endPos;
    public bool actioned = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Vector3 position = this.rectTransform.position;

        initPos = new Vector3(position.x, position.y, position.z);
        upPos = new Vector3(position.x, position.y + 800, position.z);
        endPos = new Vector3(position.x, position.y + 600, position.z);

		path = new Vector3[]{
			initPos,
			upPos,
			endPos,
		};
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(endPos.y == this.rectTransform.position.y && jumpY > 0){
            Vector3 position = this.rectTransform.position;
            jumpY -= 100;
            upPos = new Vector3(position.x, position.y + jumpY, position.z);
            initPos = endPos;
            path = new Vector3[]{
                initPos,
                upPos,
                endPos,
            };
            this.rectTransform.DOPath(path, 1.0f, PathType.CatmullRom);
        }*/
        
    }

    public void action(){
        if(actioned == false){
            this.rectTransform.DOPath(path, 1.0f, PathType.CatmullRom);
            actioned = true;
        }
    }
}
