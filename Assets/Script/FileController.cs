using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileController : MonoBehaviour {
	string path=Application.persistentDataPath+"/Data.json";

	// Use this for initialization

	public bool FileExists(){
		if(File.Exists(path)){
			Debug.Log("存在します");
			return true;
		}
		JsonDatas datas=new JsonDatas();
		string json=JsonUtility.ToJson(datas);
		//File.WriteAllText(path,json);
		FileStream fs=new FileStream(path,FileMode.Create,FileAccess.Write);
		StreamWriter sw=new StreamWriter(fs);
		sw.WriteLine(json);
		sw.Close();
		fs.Close();

		Debug.Log("ファイルを作成");

		return true;
	}

	public JsonDatas LoadDatas(){
		JsonDatas datas=new JsonDatas();
		StreamReader sr=new StreamReader(path);
		string json=sr.ReadToEnd();

		JsonUtility.FromJsonOverwrite(json,datas);
		sr.Close();
		return datas;
	}

	public void SaveDatas(JsonDatas datas){
		string json=JsonUtility.ToJson(datas);
		FileStream fs=new FileStream(path,FileMode.Create,FileAccess.Write);
		StreamWriter sw=new StreamWriter(fs);
		sw.WriteLine(json);
		sw.Close();
		fs.Close();
	}

	public int ringToCoin(int ring){
		JsonDatas datas=LoadDatas();
		datas.coins+=ring*5;
		SaveDatas(datas);
		return datas.coins;
	}

	public int itemToCoin(int item){
		JsonDatas datas=LoadDatas();
		datas.coins+=item*3;
		SaveDatas(datas);
		return datas.coins;
	}
}
