using UnityEngine;
using System.Collections;
// それぞれ、Unityエンジンの基本ライブラリを利用、システムが持つ機能ライブラリを利用、と言った宣言。
// C#スクリプト生成時に自動的に書かれるので、「基本機能の利用に必要なもの」程度の認識でおｋ。

public class Bar : MonoBehaviour {
	float	d = 1.0f;
	// MonoBehaviour（モノビヘイビア）も自動的に書かれているのでスクリプトを書くための約束事程度でおｋ。
	// ゲームオブジェクトの親となり、それを継承してオブジェクトの動き（スクリプト）を作成する。
	// 変数ｄはバーの基本移動速度を管理している。

	// Use this for initialization
	void Start () {
		d = 1.0f * Time.deltaTime;
	}

	// Start()は初回実行時のみ動作する初期化用の関数。
	//Time.deltaTimeは、直前に更新されたフレームが表示されるまでの時間を取得。
	//遅い環境ほど大きく、早い環境ほど小さい値になるためばー移動速度に乗算して環境差を調節。
	//早い環境 ■⇛■⇛■⇛■⇛■ 移動速度を遅くする。
	//遅い環境 ■⇛⇛⇛■⇛⇛⇛■  移動速度を早くする。

	// Update is called once per frame
	void Update () {
		if (Ball.endflag) {
			return;
		}

		//Update()は毎フレーム（1/60秒）ごとに実行される処理。
		//ボールに含まれるendflagをチェックし
		//「真」＝ゲームオーバーであれば何もせずにreturn
		//⇛現状は「操作が効かなくなること」で表す

		float x = Input.GetAxis ("Horizontal");// 水平方向の入力を受付 バーと壁にはリジッドボディがあるため衝突する
		float y = Input.GetAxis ("Vertical");


		//GetAxisは、指定した軸方向の入力値(-1.0~1.0)を取得する。
		//Horizontalは水平(左右)、verticalは垂直方向(上下)。
		//キー入力だけではなくジョイパッドやジョイスティック
		//
		//

		transform.Translate(new Vector2(x*d*5.0f, y*d*5.0f));
		//transformは全ゲームオブジェクトに含まれる基本的な情報。
		//position（座標）やscale（倍率）、今回のtrancelate（移動幅）など
		//普遍的に必要な機能が一通り揃っている。
	}
}
