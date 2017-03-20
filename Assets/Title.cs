using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// リターンキー（エンターキー）を押されたら
		if(Input.GetKeyDown (KeyCode.Return)){
			// 次のシーン（ゲーム）に移行する
			Application.LoadLevel ("Squash");
		}
	}
}
