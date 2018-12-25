using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REndlessStageController : MonoBehaviour {
	const int Stagesize=20;
	public GameObject player;
	public GameObject backWall;
	public GameObject []stageTips;

	public List <GameObject> generateStageList=new List<GameObject>();

	private int stagePlace=70;

	// Use this for initialization
	void Start () {
		FirstGenerate();
	}
	
	// Update is called once per frame
	void Update () {
		//プレイヤーと壁の距離が40以上なら
		float ptowLength=player.transform.position.z-backWall.transform.position.z;
		if(ptowLength>40){
			MoveWall();
		}
		if(generateStageList.Count<10){
			GenerateStage();
		}
	}
	void FirstGenerate(){
		for(int i=1;i<10;i++){
			GenerateStage();
		}
	}

	void GenerateStage(){
		int stageNum=Random.Range(0,stageTips.Length);
		GameObject stageObject=(GameObject)Instantiate(
			stageTips[stageNum],
			new Vector3(0,0,stagePlace),
			Quaternion.identity
		);
		stagePlace+=Stagesize;
		generateStageList.Add(stageObject);
	}

	void MoveWall(){
		backWall.transform.Translate(0,0,20);
		DestroyOldStage();
	}

	void DestroyOldStage(){
		GameObject oldStage=generateStageList[0];
		generateStageList.RemoveAt(0);
		Destroy(oldStage);
	}
}
