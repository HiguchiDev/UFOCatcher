using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCase : MonoBehaviour
{
    private UFOAnimationSwitcher ufoAnimationSwitcher;

    public bool sideMoved = false;
    public bool backMoved = false;
    public bool sideMoving = false;
    public bool backMoving = false;
    public bool playing = false;

    private Coin coin;
    private GameObject sideMoveButton;
    private GameObject backMoveButton;
    
    // Start is called before the first frame update
    void Start()
    {
        this.sideMoveButton = GameObject.Find("SideMoveButton");
        this.backMoveButton = GameObject.Find("BackMoveButton");
        ufoAnimationSwitcher = GameObject.Find("UFOAnimationSwitcher").GetComponent<UFOAnimationSwitcher>();
        this.sideMoveButton.GetComponent<Renderer>().material.color = Color.gray;
        this.backMoveButton.GetComponent<Renderer>().material.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        if(ufoAnimationSwitcher.isWait() &&
            sideMoved && backMoved && sideMoving && backMoving && playing){
            sideMoved = false;
            backMoved = false;
            sideMoving = false;
            backMoving = false;
            this.playing = false;
            this.sideMoveButton.GetComponent<Renderer>().material.color = Color.gray;
            this.backMoveButton.GetComponent<Renderer>().material.color = Color.gray;
        }

        if(this.coin != null && this.coin.actionEnd){
            this.playing = true;
            this.coin = null;
            this.sideMoveButton.GetComponent<Renderer>().material.color = Color.yellow;
            this.backMoveButton.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    public void insertCoin(Coin coin){
        this.coin = coin;
    }

    public bool canPlay(){
        return this.playing == false;
    }

    public void pushSideMoveButton(){
        if(sideMoved == false && this.playing){
            sideMoving = true;
            ufoAnimationSwitcher.moveLeft();
        }
    }

    public void releaseSideMoveButton(){
        if(sideMoving && this.playing){
            sideMoved = true;
            ufoAnimationSwitcher.stopMove();
        }
    }

    public void pushBackMoveButton(){
        if(!backMoved && sideMoved && this.playing){
            backMoving = true;
            ufoAnimationSwitcher.moveBack();
        }
    }

    public void releaseBackMoveButton(){
        if(backMoving && this.playing){
            backMoved = true;
            ufoAnimationSwitcher.stopMove();
        }
    }
}
