using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSri : MonoBehaviour {


	public MakerSri makerS;
	public GameObject demoP;
	public GameObject demoB;
	public GameObject[] instD;
	int index= 0;

	// Use this for initialization
	void Start () {
		Debug.Log ("Inside Demo Script");
		int a = PlayerPrefs.GetInt ("isDemoShown", 0);
		//a = 0;
		if (a >= 2) {
			demoP.SetActive (false);
			return;
		} else {
			a++;
			PlayerPrefs.SetInt ("isDemoShown", a);
			makerS.Pause ();
			demoP.SetActive (true);
			HideAll ();
			index = 0;
			NextD ();
			demoB.SetActive (false);
		}
	}

	public void Show(){
		makerS.Pause ();
		demoP.SetActive (true);
		HideAll ();
		index = 0;
		NextD ();
		demoB.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HideAll(){
		for (int i = 0; i < instD.Length; i++) {
			instD [i].SetActive (false);
		}
	}

	public void NextD(){
		HideAll ();
		if (index >= instD.Length) {
			demoP.SetActive (false);
			makerS.Pause ();
			demoB.SetActive (true);
			return;
		}
		instD [index].SetActive (true);
		index++;
	}


}//classEND
