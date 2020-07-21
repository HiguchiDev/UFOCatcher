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
        ufo.AddComponent<ArmOpener>();
        ufoAction = ufo.GetComponent<ArmOpener>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ufoAction.isActionEnd()){
            ufoAction.after();
            ufoAction = ufoAction.exchangeNextScript(ufo);
            Debug.Log("next action");
        }
    }
}
