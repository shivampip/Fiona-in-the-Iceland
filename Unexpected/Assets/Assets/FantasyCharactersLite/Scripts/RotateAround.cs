using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Rotates the  camera around for the demo
 **/
public class RotateAround : MonoBehaviour {

	public GameObject target;
	public float speed = 1;
	float floatLockedRotation = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") != 0)
			rotateStop();
		transform.RotateAround (target.transform.position, Vector3.up, speed * Time.deltaTime * (Input.GetAxis("Horizontal") + floatLockedRotation));
		//floatLockedRotation = 0;
	}

	public void rotateLeft(){
		floatLockedRotation = -.3f;
	}

	public void rotateRight(){
		floatLockedRotation = .3f;
	}

	public void rotateStop(){
		floatLockedRotation = 0;
	}
}
