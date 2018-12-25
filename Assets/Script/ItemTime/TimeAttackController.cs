using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeAttackController : MonoBehaviour {
	private GameController controller;
	public GameObject rig;
	public GameObject bird;
	public GameObject[] startPosition;
	private List<GameObject> itemList = new List<GameObject> ();
	private int maxitemNum = 20;
	public Text timeText;
	private float time = 120f;
	private RigCollisionController rcController;
	public GameObject clearText;
	public GameObject gameOverText;
	private FileController fc;
	private bool isClear = false;

	// Use this for initialization
	void Start () {
		int pos = Random.Range (0, startPosition.Length);

		//スタート位置ランダム
		rig.transform.position = startPosition[pos].transform.position;
		rig.transform.localEulerAngles = startPosition[pos].transform.localEulerAngles;
		bird.transform.position = startPosition[pos].transform.position;
		bird.transform.localEulerAngles = startPosition[pos].transform.localEulerAngles;

		//アイテム配置
		GetItemChild ();
		SelectItem ();

		rcController = rig.GetComponent<RigCollisionController> ();
		controller = this.gameObject.GetComponent<GameController> ();
		fc = new FileController ();
		clearText.SetActive (false);
		gameOverText.SetActive (false);
	}

	void Update () {
		if (rcController.getIsDead ()) {
			GameOver ();
		} else {
			time -= Time.deltaTime;
			timeText.text = "Time:" + time + "s";

			if (maxitemNum <= rcController.GetItemCount ()) {
				isClear = true;
				Clear (time);
			}
		}

	}
	void OnDestroy () {
		SaveData (time);
	}

	void GetItemChild () {
		GameObject Item = GameObject.Find ("Items");
		foreach (Transform transform in Item.transform) {
			var oneitem = transform.gameObject;
			oneitem.SetActive (false);
			itemList.Add (oneitem);
		}
	}

	void SelectItem () {
		for (int i = 0; i < maxitemNum; i++) {
			int num = Random.Range (0, itemList.Count - 1);
			GameObject item = itemList[num];
			item.SetActive (true);
			itemList.Remove (item);
		}
	}

	void Clear (float time) {
		//クリア処理
		clearText.SetActive (true);
		//SaveData (time);
		//シーン移動
		Invoke ("LoadScene", 2.0f);
	}
	void GameOver () {
		//死亡処理
		controller.setSpeed (0);
		gameOverText.SetActive (true);
		//SaveData (time);
		Invoke ("LoadScene", 2.0f);
	}
	void LoadScene () {
		SceneManager.LoadScene ("itemModeSelect");
	}
	void SaveData (float time) {
		JsonDatas datas = fc.LoadDatas ();
		//スコア記録
		if (datas.itemTimeAttack == 0) {
			datas.itemTimeAttack = time;
			fc.SaveDatas (datas);
		} else if (isClear && time > datas.itemTimeAttack) {
			datas.itemTimeAttack = time;
			fc.SaveDatas (datas);
		}
		//アイテム換算
		fc.itemToCoin (rcController.GetItemCount ());
	}
}