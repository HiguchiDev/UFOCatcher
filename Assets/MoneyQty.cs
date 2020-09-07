using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyQty : MonoBehaviour
{
    private TextMeshProUGUI textbox_name;
    private Wallet wallet;
    private int beforeCoinQty = 0;

    // Start is called before the first frame update
    void Start()
    {
		//テキストボックス取得
		textbox_name = this.GetComponent<TextMeshProUGUI>();
        wallet = GameObject.Find("Wallet").GetComponent<Wallet>();
		//テキスト反映
		textbox_name.text = "Coin × " + wallet.getCoinQty();
        beforeCoinQty = wallet.getCoinQty();
    }

    // Update is called once per frame
    void Update()
    {
        if(beforeCoinQty != wallet.getCoinQty()){
            beforeCoinQty = wallet.getCoinQty();
            textbox_name.text = "Coin × " + wallet.getCoinQty();
        }
    }
}
