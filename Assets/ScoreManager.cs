using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using UnityEngine.UI;  // 追加しましょう
 
public class ScoreManager : MonoBehaviour {
 
 
    public Text score_text = null; // Textオブジェクト
 
      // 初期化
      void Start () {
        // オブジェクトからTextコンポーネントを取得
        score_text = this.GetComponent<Text> ();
      }
 
      // 更新
      void Update () {
        
        // テキストの表示を入れ替える
        score_text.text = GameParameters.score + "円目";
      }
}