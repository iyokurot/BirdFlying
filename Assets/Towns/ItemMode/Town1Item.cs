using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town1Item : MonoBehaviour {
	public List<GameObject> itemObjects=new List<GameObject>();
	private int generateitemNum=0;

	// Use this for initialization
	void Start () {
		//リストオブジェクトをすべてfalseに
		foreach(GameObject obj in itemObjects){
			obj.SetActive(false);
		}
		//生成個数をランダム指定
		generateitemNum=Random.Range(1,itemObjects.Count);
		//生成位置をランダム選択＊forループ
		for(int i=0;i<generateitemNum;i++){
			GeneratePlace();
		}
		
	}

	void GeneratePlace(){
		int getnum=Random.Range(0,itemObjects.Count-1);
		GameObject obj=itemObjects[getnum];
		itemObjects.RemoveAt(getnum);
		obj.SetActive(true);
	}
}
