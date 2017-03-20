using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	float	d = 1.0f;		//ボールの基本移動速度
	float	dx = 0.2f;	// ボールの初期移動量(x,y)
	float	dy = 0.1f;	// 0.1だと遅く感じるが、0.5あたりはとても速い
								//正数ならx:右/y:上
								//負数ならx:左/y:下
	int counter = 0;	//物理演算のカウンター
	public static bool endflag = false;		//ゲームオーバー条件のフラグ
	public static int LeftBall = 2; 					//残りボール
	public static int Bar = 10;						//あたっていい回数

	//publicは他のスクリプトからもアクセスできる共有指定
	//staticは内容を保持して次実行時に前回内容を継続
	// boolは真と偽


	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(d*dx, d*dy));
		d = 50.0f * Time.deltaTime;
	}

	//ボールの初期移動ベクトルを設定
	//AddFouce()はゲームオブジェクトに移動方向を与え
	//ゲームスタートと同時にボールが動く出す仕掛けになる。

	void FixedUpdate(){
		if (Ball.endflag) {
			return;
		}

		//FixedUpdateは一定時間ごとに確実に実行される物理演算のための更新関数
		//タイミングがズレると物理的な動きか不自然になるため、Updateよりも精度・確実度が高い。
		//今回のような、操作でなく物理法則(？)に基づいて自動的に動くようなオブジェクトに有効。

		counter++;
		if (counter == 1000) {
			counter = 0;

			//実行回数をカウントアップ、MAX1000としてゼロに戻すことで時間経過で徐々に速度が上がり、
			//一定時間で遅くなる少しずつ難しくなるようなゲーム表現になっている。

			Vector2 v = GetComponent<Rigidbody2D>().velocity;
			v.x /= 100.0f;
			v.y /= 100.0f;
			GetComponent<Rigidbody2D>().AddForce (v);
		}
	}

	//GetComponentで、このゲームオブジェクト＝ボールの情報をにアクセス出来る。
	//velocityはゲームオブジェクトに働いているベクトル
	
	void OnCollisionEnter2D(Collision2D collision){
		if (Ball.endflag) {
			return;
		}

		//OnCollisionEnter2Dは、このオブジェクトに2Dの当たり判定が発生した時に実行される。
		//引数として当たり判定の相手のCollision2Dオブジェクトが入ってくるので、相手の情報にもある程度アクセス出来る。

		if(collision.gameObject.tag == "EndWall"){
			LeftBall -= 1;		//ボール-1
			Bar -= 1;
			if(LeftBall < 0 || Bar < 0){
				endflag = true;
				Application.LoadLevel("Squash_GameOver");
			}
		}
		//当たり判定の相手は引数collisionとして利用可能。
		//相手のタグ名がEndWallなら下の壁にあたったと判断、ゲームオーバーとして終了フラグを立てる。

		if(collision.gameObject.tag == "Block"){
			Destroy(collision.gameObject);
			Score.score += 10;
		}

		Vector2 v = GetComponent<Rigidbody2D>().velocity;
		float rnd = Random.value;
		v.x *= 1+rnd/2-rnd;
		if(Mathf.Abs(v.x)<1.0f){
			v.x *= 2.0f;
		}
		if(Mathf.Abs(v.y)<1.0f){
			v.y *= 2.0f;
		}
		GetComponent<Rigidbody2D>().velocity = v;
		//何に当たったとしても、乱数によりボールのベクトルを微妙に増大させ、少しずつ難しくする処理
	}
	
	
	// Update is called once per frame
	void Update () {
		//使ってない
	}
}
