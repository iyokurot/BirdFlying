using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBallController : MonoBehaviour {
	public GameObject endButton;

	// Use this for initialization
	void Start () {
		endButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision hit){
		if(hit.gameObject.tag=="Player"){
			endButton.SetActive(true);
		}
	}

	public void onEndButtonClicked(){
		SceneManager.LoadScene("ModeSelectScene");
	}

	public void onContinueButtonClicked(){
		endButton.SetActive(false);
	}
}
