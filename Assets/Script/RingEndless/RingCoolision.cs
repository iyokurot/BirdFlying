using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class RingCoolision : MonoBehaviour {
	public Text ringNum;
	private int ringCount=0;
	private GameObject backWall;
	private BackWallController script;
	

	// Use this for initialization
	void Start () {
		ringNum.text="Ring : "+ringCount;
		backWall=GameObject.Find("BackWall");
		script=backWall.GetComponent<BackWallController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision hit){
		if(hit.gameObject.tag=="ring"){
			//destroy処理
			Destroy(hit.gameObject);
			//リング数加算処理
			ringCount++;
			ringNum.text="Ring : "+ringCount;
		}else{
			//リング数記録
			scoreDataSave();
			script.LoadGameOver();
		}
	}

	void scoreDataSave(){
		FileController fc=new FileController();
		JsonDatas datas=fc.LoadDatas();
		//ハイスコアなら
		if(datas.ringEndless<ringCount){
			datas.ringEndless=ringCount;
			fc.SaveDatas(datas);
		}

		//リングコイン変換
		fc.ringToCoin(ringCount);
	}
}
