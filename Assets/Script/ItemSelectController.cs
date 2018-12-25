using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemSelectController : MonoBehaviour {
	public Text endless;
	public Text timeAttack;

	// Use this for initialization
	void Start () {
		FileController fc = new FileController ();
		JsonDatas datas = fc.LoadDatas ();

		endless.text = "Score:" + datas.itemEndless;
		timeAttack.text = "BestTime:" + datas.itemTimeAttack;
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnBackClicked () {
		SceneManager.LoadScene ("ModeSelectScene");
	}

	public void OnEndlessClicked () {
		SceneManager.LoadScene ("ItemEndlessScene");
	}

	public void OnTimeAttackClicked () {
		SceneManager.LoadScene ("ItemTimeAttackScene");
	}
}