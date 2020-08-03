using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected GameObject ufo;
    private GameCase gameCase;

    // Start is called before the first frame update
    void Start()
    {
        ufo = GameObject.Find("UFO");
        gameCase = GameObject.Find("Case").GetComponent<GameCase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            gameCase.pushSideMoveButton();
        }
        if(Input.GetKeyUp(KeyCode.A)){
            gameCase.releaseSideMoveButton();
        }
        if(Input.GetKeyDown(KeyCode.S)){
            gameCase.pushBackMoveButton();
        }
        if(Input.GetKeyUp(KeyCode.S)){
            gameCase.releaseBackMoveButton();
        }
    }   
}
