using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdMove : MonoBehaviour {
	//public GameObject bird;
	public Camera camera;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//カメラの視線方向に移動
		/*
		float cameraRotateY=camera.transform.localEulerAngles.y;
		float cameraRotateX=camera.transform.localEulerAngles.x;
		if(cameraRotateX>30)cameraRotateX=30;
		if(cameraRotateX<-30)cameraRotateX=-30;
		cameraRotateX=0;
		this.transform.Rotate(cameraRotateX,cameraRotateY,0);
		
		Vector3 nowAngle=this.transform.localEulerAngles;
		float angleX=nowAngle.x;
		if(angleX>30)nowAngle.x=30;
		if(angleX<-30)nowAngle.x=-30;
		this.transform.localEulerAngles=nowAngle;
		

		//this.transform.Translate(0,0,0.1f);
		*/
		//camera.transform.Translate(0,0,0.1f);
	}
}
