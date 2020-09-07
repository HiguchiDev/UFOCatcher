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
    
    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void insertCoin(){
        this.playing = true;
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
