using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score;	//得点

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Ball.endflag){
			GetComponent<TextMesh>().text = "GAME OVRE";
		}
		else{
			GetComponent<TextMesh>().text = "SCORE:" + score.ToString();
		}
	}
}
