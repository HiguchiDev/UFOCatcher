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
    
    // Start is called before the first frame update
    void Start()
    {
        ufoAnimationSwitcher = GameObject.Find("UFOAnimationSwitcher").GetComponent<UFOAnimationSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void catchItem(){
        if(sideMoved && backMoved){
            ufoAnimationSwitcher.catchItem();
        }
    }

    public void pushSideMoveButton(){
        if(sideMoved == false){
            sideMoving = true;
            ufoAnimationSwitcher.moveLeft();
        }
    }

    public void releaseSideMoveButton(){
        if(sideMoving){
            sideMoved = true;
            ufoAnimationSwitcher.stopMove();
        }
    }

    public void pushBackMoveButton(){
        if(!backMoved && sideMoved){
            backMoving = true;
            ufoAnimationSwitcher.moveBack();
        }
    }

    public void releaseBackMoveButton(){
        if(backMoving){
            backMoved = true;
            ufoAnimationSwitcher.stopMove();
        }
    }
}
