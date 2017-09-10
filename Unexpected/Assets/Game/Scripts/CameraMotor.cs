using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	public GameObject mainCam;

	private Transform lookAt;
	private Vector3 offset;
	private Vector3 moveVector;

	//Start camera animation
	private float transition= 0.0f;
	private float duration= 7.0f;
	private Vector3 animationOffset= new Vector3(0f,1.7f,2f);

	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - lookAt.position;
	}

	// Update is called once per frame
	void Update () {
		moveVector = lookAt.position + offset;
		//X
		moveVector.x= 0;
		//Y
		moveVector.y= Mathf.Clamp(moveVector.y, -0.7f,10f);

		if (transition > 1.0f) {
			mainCam.SetActive (true);
			Destroy (gameObject);
			transform.position = moveVector;
		} else {
			//Animation at start of the Game
			transform.position= Vector3.Lerp(moveVector+animationOffset, moveVector, transition);
			transition += Time.deltaTime * 1 / duration;
			transform.LookAt (lookAt.position + Vector3.up);
		}

	}//UpdateEND
}
