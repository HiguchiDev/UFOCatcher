using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    protected GameObject ufo;
    private GameCase gameCase;
    private Wallet wallet;
    private GameObject coinPrefab;
    private GameObject coinInstance;

    void Awake()
    {
        wallet = GameObject.Find("Wallet").GetComponent<Wallet>();
        wallet.setCoin(10);
    }

    // Start is called before the first frame update
    void Start()
    {
        coinPrefab = (GameObject)Resources.Load("Coin");
 
        ufo = GameObject.Find("UFO");
        gameCase = GameObject.Find("GameCase").GetComponent<GameCase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameCase.canPlay()){
            bool coin = wallet.takeoutOneCoin();

            if(coin){
                GameObject coinInstance = (GameObject)Instantiate(coinPrefab, coinPrefab.transform.position, Quaternion.identity);
                gameCase.insertCoin(coinInstance);
            }
            
        }
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

        if(Input.GetKeyDown(KeyCode.L)){
            SceneManager.LoadScene("Title");
        }
    }   
}
