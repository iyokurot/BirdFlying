using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class JsonDatas : MonoBehaviour {
	//所持コイン数
	public int coins;
	//鳥モデルNo.0~6
	public int birdmodel;
	//リングエンドレスモード記録
	public int ringEndless;
	//リングステージ１記録
	public int ringstage1;
	//アイテムエンドレスモード記録
	public int itemEndless;
	//アイテムタイムアタック記録
	public float itemTimeAttack;
}