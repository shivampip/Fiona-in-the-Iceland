using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidhaSri : MonoBehaviour {

	public bool isVisited;
	public bool isTurn;

	// Use this for initialization
	void Start () {
		isVisited = false;
	
	}


	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			//Debug.Log ("Entered "+isTurn);
			if (isTurn) {
				other.GetComponent<PlayerMotor> ().isTurnable = true;
			} else {
				other.GetComponent<PlayerMotor> ().isTurnable = false;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if(other.CompareTag("Player")){
			//Debug.Log("Exited");
			isVisited = true;
			//MakerSri.generate ();
		}
	}

}
