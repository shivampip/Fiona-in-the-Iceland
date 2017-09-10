using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoverSri : MonoBehaviour {

	public GameObject gate;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Destroy (gate);
		}
	}


}//classEND
