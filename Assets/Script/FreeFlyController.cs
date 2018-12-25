using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeFlyController : MonoBehaviour {
	//public float speed;
	GameController script;

	public Slider speedSlider;

	// Use this for initialization
	void Start () {
		script=this.gameObject.GetComponent<GameController>();
		speedSlider.value=1;
	}
	
	// Update is called once per frame
	void Update () {
		script.setSpeed(speedSlider.value);
	}
}
