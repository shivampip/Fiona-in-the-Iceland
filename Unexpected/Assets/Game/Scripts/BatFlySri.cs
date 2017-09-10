using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFlySri : MonoBehaviour {

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		fly = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!fly) {
			return;
		}
		rigidBody.AddForce(transform.forward*-1*150f);
	}

	private bool fly;

	public void startFlying(){
		fly = true;
	}
}
