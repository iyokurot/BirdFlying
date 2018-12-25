using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IEBackWall : MonoBehaviour {
public GameObject gameoverText;

	// Use this for initialization
	void Start () {
		gameoverText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision hit){
		if(hit.gameObject.tag=="Player"){
			LoadGameOver();
		}
	}

	public void LoadGameOver(){
		gameoverText.SetActive(true);
			Invoke("LoadRModeSelect",2.0f);
	}

	void LoadRModeSelect(){
		SceneManager.LoadScene("itemModeSelect");
	}
}
