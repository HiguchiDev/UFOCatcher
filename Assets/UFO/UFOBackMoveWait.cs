using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBackMoveWait : UFOAction
{
    private bool isEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override bool isActionEnd() {
        return isEnd;
    }

    public void startBackMove(){
        isEnd = true;
    }

    public override UFOAction exchangeNextScript(GameObject obj) {
        Destroy(this);
        obj.AddComponent<UFOBackMover>();
        return obj.GetComponent<UFOBackMover>();
    }
}
