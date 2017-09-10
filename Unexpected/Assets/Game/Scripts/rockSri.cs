using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSri : MonoBehaviour {

	public rockTriggerSri rts;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
	}


	// Update is called once per frame
	void Update () {
		if (rts.isEntered) {
			rb.useGravity = true;
		}

	}



}//classEND
