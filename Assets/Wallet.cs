using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int coinQty = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool takeoutOneCoin(){
        if(this.coinQty <= 0){
            return false;
        }

        this.coinQty--;
        return true;
    }

    public void setCoin(int qty)
    {
        this.coinQty = qty;
    }

    public int getCoinQty()
    {
        return this.coinQty;
    }
}
