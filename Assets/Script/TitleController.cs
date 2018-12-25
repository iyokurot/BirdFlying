using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;


public class TitleController : MonoBehaviour {
	public Text startText;
	private float time;

	private float speed=0.7f;


	// Use this for initialization
	void Start () {
		XRSettings.enabled=false;
		//ファイル存在確認
		fileExist();
	}
	
	// Update is called once per frame
	void Update () {
		updateText();
		if(Input.GetMouseButton(0)){
			OnStartButtonClicked();
		}
	}

	public void OnStartButtonClicked()
	{
		SceneManager.LoadScene("HomeScene");
	}
	public bool fileExist(){

		FileController fileController=new FileController();
		fileController.FileExists();
		return true;
	}

	void updateText(){
		var color=startText.color;
		time+=Time.deltaTime*5.0f*speed;
		color.a=Mathf.Sin(time)*0.5f+0.5f;
		startText.color=color;
	}
}
