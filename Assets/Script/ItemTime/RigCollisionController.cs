using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RigCollisionController : MonoBehaviour {
	private int itemCount=0;
	public Text itemcountText;
	private bool isDead=false;

	// Use this for initialization
	void Start () {
		ItemText(itemCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision hit){
		if(hit.gameObject.tag=="item"){
			itemCount++;
			hit.gameObject.SetActive(false);
			ItemText(itemCount);
		}else{
			isDead=true;
		}
	}
	void ItemText(int count){
		itemcountText.text="Item : "+itemCount+"/20";
	}

	public int GetItemCount(){
		return itemCount;
	}
	public bool getIsDead(){
		return isDead;
	}
}
