using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOAnimationSwitcher : MonoBehaviour
{

    private GameObject ufo;
    private UFOAction ufoAction;
    
    // Start is called before the first frame update
    void Start()
    {
        ufo = GameObject.Find("UFO");

    }

    // Update is called once per frame
    void Update()
    {
        if(ufoAction != null && ufoAction.isActionEnd()){
            ufoAction.after();
            ufoAction = ufoAction.exchangeNextScript(ufo);
            Debug.Log("next action");
        }
    }

    public void catchItem(){
        if(isWait()){
            destroyUFOActions(ufo);
            destroyUFOActions(GameObject.Find("RightArm"));
            destroyUFOActions(GameObject.Find("LeftArm"));

            ufo.AddComponent<ArmOpener>();
            ufoAction = ufo.GetComponent<ArmOpener>();


        }
    }

    public void moveLeft(){
        if(isWait()){
            destroyUFOActions(ufo);
            destroyUFOActions(GameObject.Find("RightArm"));
            destroyUFOActions(GameObject.Find("LeftArm"));

            ufo.AddComponent<UFOLeftMover>();
            ufoAction = ufo.GetComponent<UFOLeftMover>();
        }
    }

    public void moveBack(){
        if(ufoAction is UFOBackMoveWait){
            destroyUFOActions(ufo);
            destroyUFOActions(GameObject.Find("RightArm"));
            destroyUFOActions(GameObject.Find("LeftArm"));

            UFOBackMoveWait wait = (UFOBackMoveWait)ufoAction;
            wait.startBackMove();

        }
    }

    public void stopMove(){
        if(ufoAction is UFOMover){
            UFOMover mover = (UFOMover)ufoAction;

            mover.stop();
        }
    }

    private bool isWait(){
        return ufo.GetComponent<UFOWait>() != null;
    }

    private void destroyUFOActions(GameObject obj){
        UFOAction[] ufoActions = obj.GetComponents<UFOAction> ();

        foreach (UFOAction action in ufoActions) {
            Destroy(action);
        }
    }
}
