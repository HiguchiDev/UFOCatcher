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

    private GameObject coin;
    private GameObject sideMoveButton;
    private GameObject backMoveButton;
    
    // Start is called before the first frame update
    void Start()
    {
        this.sideMoveButton = GameObject.Find("SideMoveButton");
        this.backMoveButton = GameObject.Find("BackMoveButton");
        ufoAnimationSwitcher = GameObject.Find("UFOAnimationSwitcher").GetComponent<UFOAnimationSwitcher>();

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
        }

        if(this.coin != null && this.coin.GetComponent<Coin>().actionEnd){
            this.playing = true;
            Destroy(this.coin);
            this.coin = null;
            sideMoveButton.GetComponent<MoveButton>().active();
        }
    }

    public void insertCoin(GameObject coin){
        this.coin = coin;
    }

    public bool canPlay(){
        return this.playing == false && this.coin == null;
    }

    public void pushSideMoveButton(){
        if(sideMoved == false && this.playing){
            sideMoving = true;
            ufoAnimationSwitcher.moveLeft();
        }
    }

    public void releaseSideMoveButton(){
        if(!backMoved && sideMoving && this.playing){
            sideMoved = true;
            ufoAnimationSwitcher.stopMove();
            sideMoveButton.GetComponent<MoveButton>().inactive();
            backMoveButton.GetComponent<MoveButton>().active();
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
            backMoveButton.GetComponent<MoveButton>().inactive();
        }
    }
}
