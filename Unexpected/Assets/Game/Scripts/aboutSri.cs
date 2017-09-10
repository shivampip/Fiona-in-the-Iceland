using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aboutSri : MonoBehaviour {

	public GameObject aboutD, infoD;

	// Use this for initialization
	void Start () {
		aboutD.SetActive (false);
		infoD.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ShowAbout(){
		aboutD.SetActive (true);
	}

	public void showInfo(){
		infoD.SetActive (true);
	}

	public void CloseDia(){
		aboutD.SetActive (false);
		infoD.SetActive (false);
	}


	public void OpenFb(){
		Application.OpenURL("https://www.facebook.com/RisingHopeApps/");
	}

	public void OpenInsta(){
		Application.OpenURL("https://www.instagram.com/shivam.3012/");
	}

	public void OpenWeb(){
		Application.OpenURL("http://risinghopeapps.weebly.com/");
	}

}//classEND
