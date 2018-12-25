using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class RingListController : MonoBehaviour {
	public Text endless;
	public Text stage1;

	// Use this for initialization
	void Start () {
		FileController fc=new FileController();
		JsonDatas datas=fc.LoadDatas();

		endless.text=datas.ringEndless+"";
		stage1.text=datas.ringstage1+"/x";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onBackButtonClicked(){
		SceneManager.LoadScene("ModeSelectScene");
	}

	public void onEndlessModeClicked(){
		SceneManager.LoadScene("RingEndless");
	}
}
