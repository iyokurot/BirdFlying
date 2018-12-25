using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClickBack(){
		SceneManager.LoadScene("HomeScene");
	}

	public void onClickRingMode(){
		SceneManager.LoadScene("RingModeSelect");
	}

	public void onClickItemMode(){
		SceneManager.LoadScene("itemModeSelect");
	}

	public void onClickFreeFlyMode(){
		SceneManager.LoadScene("FreeFlyScene");
	}
}
