using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAndWallCollision : MonoBehaviour {
	public Text itemNum;

	private int itemCount=0;
	private GameObject backWall;
	private IEBackWall script;

	// Use this for initialization
	void Start () {
		TextChanger(itemCount);
		backWall=GameObject.Find("BackWall");
		script=backWall.GetComponent<IEBackWall>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision hit){
		if(hit.gameObject.tag=="item"){
			Destroy(hit.gameObject);
			itemCount++;
			TextChanger(itemCount);
		}else{
			ScoreSave();
			script.LoadGameOver();
		}
	}

	void TextChanger(int count){
		itemNum.text="Item : "+count;
	}

	void ScoreSave(){
		FileController fc=new FileController();
		JsonDatas datas=fc.LoadDatas();
		if(datas.itemEndless<itemCount){
			datas.itemEndless=itemCount;
			fc.SaveDatas(datas);
		}
		//アイテムコイン変換
		fc.itemToCoin(itemCount);
	}
}
