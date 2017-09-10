using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockTriggerSri : MonoBehaviour {

	public bool isEntered;

	void Start(){
		isEntered = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			isEntered = true;
		}
	}

}
