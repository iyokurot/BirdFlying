using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour {
	public GameObject rig;
	public GameObject bird;
	private Vector3 newAngle = new Vector3 (0, 0, 0);
	private Vector3 lastMousePosition;

	private float moveMlength = 50;

	private float speed = 0.1f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//camera.transform.RotateAround(bird.transform.position,new Vector3(1,0,0),-newAngle.x);

		UpdateCameraRotation ();

	}
	void FixedUpdate () {
		rig.transform.Translate (0, 0, speed);
		birdMove ();
	}

	void UpdateCameraRotation () {

		//Unity上
#if UNITY_EDITOR
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
#else
		//スマホ上
		if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch (0).fingerId)) {
			return;
		}
#endif

		if (Input.GetMouseButtonDown (0)) {
			newAngle = rig.transform.localEulerAngles;
			lastMousePosition = Input.mousePosition;
		} else if (Input.GetMouseButton (0)) {
			float differenceX = Input.mousePosition.x - lastMousePosition.x;
			float differenceY = Input.mousePosition.y - lastMousePosition.y;
			if (differenceX > moveMlength) differenceX = moveMlength;
			if (differenceY > moveMlength) differenceY = moveMlength;
			if (differenceX < -moveMlength) differenceX = -moveMlength;
			if (differenceY < -moveMlength) differenceY = -moveMlength;
			newAngle.y -= (differenceX) * 0.1f;
			newAngle.x -= (differenceY) * 0.1f;
			rig.transform.localEulerAngles = newAngle;

			lastMousePosition = Input.mousePosition;
		} else {
			/*
			camera.gameObject.transform.localEulerAngles=newAngle;
			if(newAngle.x>0)newAngle.x-=0.1f;
			if(newAngle.x<0)newAngle.x+=0.1f;
			if(newAngle.y>0)newAngle.y-=0.1f;
			if(newAngle.y<0)newAngle.y+=0.1f;
			//newAngle=new Vector3(0,0,0);
			*/
		}

	}

	void birdMove () {
		bird.transform.position = rig.transform.position;
		bird.transform.localEulerAngles = rig.transform.localEulerAngles;
	}

	public void setSpeed (float newspeed) {
		speed = newspeed;
	}
}