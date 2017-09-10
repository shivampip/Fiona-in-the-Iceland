using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTriggerSri : MonoBehaviour {

	public BatFlySri batFlySri;

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			batFlySri.startFlying ();
		}
	}


}
