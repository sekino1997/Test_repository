using UnityEngine;
using System.Collections;

public class GaneOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Return)){
			// ゲームを初期状態に戻す
			Score.score = 0;
			Ball.endflag = false;
			Ball.LeftBall = 2;
			// タイトルに戻る
			Application.LoadLevel ("Squash_Title");
		}
	}
}
