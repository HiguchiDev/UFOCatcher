using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Coin : MonoBehaviour
{
    public bool actionEnd = false;
    public GameObject moneySlot;

    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("init");
        moneySlot = GameObject.Find("MoneySlotHole");

        if(moneySlot != null){
            this.action();
        }

        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
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
        if(actionEnd == false){
            Vector3[] path = new Vector3[]{
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                new Vector3(
                                moneySlot.transform.position.x ,
                                Math.Abs(this.transform.position.y) * 12,
                                this.transform.position.z + Math.Abs(Math.Abs(this.transform.position.z) - Math.Abs(moneySlot.transform.position.z)) / 2
                            ),
                //new Vector3(moneySlot.transform.position.x, moneySlot.transform.position.y + Math.Abs(moneySlot.transform.position.y) / 2, moneySlot.transform.position.z),
                new Vector3(moneySlot.transform.position.x, moneySlot.transform.position.y, moneySlot.transform.position.z),
                new Vector3(moneySlot.transform.position.x, moneySlot.transform.position.y + (moneySlot.transform.position.y * 0.1f), moneySlot.transform.position.z)
            };

            Debug.Log("point1: " + new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z));
            Debug.Log("point2: " + new Vector3(
                                moneySlot.transform.position.x ,
                                Math.Abs(this.transform.position.y) * 12,
                                this.transform.position.z + Math.Abs(Math.Abs(this.transform.position.z) - Math.Abs(moneySlot.transform.position.z)) / 2
                            ));
            Debug.Log("point3: " + new Vector3(moneySlot.transform.position.x, moneySlot.transform.position.y, moneySlot.transform.position.z));
            //Debug.Log("point4: " + new Vector3(moneySlot.transform.position.x, moneySlot.transform.position.y + 10.0f, moneySlot.transform.position.z));
            

            this.transform.DOPath(
                path,
                1.5f,
                PathType.CatmullRom
            ).OnComplete(() =>
                {
                    this.actionEnd = true;
                });
        }
    }
}
