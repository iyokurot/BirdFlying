using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour {
	public Text coinText;
	GameObject birds;
	JsonDatas datas;
	private string json;

	private string fromJson;

	// Use this for initialization
	void Start () {

		//データの読み込み
		FileController fc = new FileController ();
		JsonDatas fromdatas = fc.LoadDatas ();
		//鳥データ読み込み
		LoadBirds (fromdatas.birdmodel);
		coinText.text = "coins : " + fromdatas.coins;
	}

	// Update is called once per frame
	void Update () {

	}
	void LoadBirds (int num) {
		birds = GameObject.Find ("BirdObjects");
		List<GameObject> models = new List<GameObject> ();
		foreach (Transform transform in birds.transform) {
			var oneitem = transform.gameObject;
			oneitem.SetActive (false);
			models.Add (oneitem);
		}
		models[num].SetActive (true);
	}

	public void onClickPlay () {
		SceneManager.LoadScene ("ModeSelectScene");
	}

	public void onClickShop () {
		//SceneManager.LoadScene("");
	}
}