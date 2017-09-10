using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCamSri : MonoBehaviour {

	public GameObject msgToPrincess, blackScreen, nextB, msgImg;
	public Animator camAnim, uiAnim, stoneAnim;
	public Text msgTv;


	string []msgs= new string[]{
		"Hi, Meet Nattu, a naughty prince. And lovely brother of Fiona. ",
		"She is Fiona. Brave princess of Fairyland. Enjoying Life.....",
		"But one day, Something Unexpected happened. And...."
	};

	// Use this for initialization
	void Start () {
		msgTv.text = msgs [0];
		msgToPrincess.SetActive (false);
		blackScreen.SetActive (false);
	}


	bool isTri=false;
	public void ShowMsgToPrincess(){
		msgToPrincess.SetActive (true);
		nextB.SetActive (false);
		msgImg.SetActive (false);
		if (!isTri) {
			isTri = true;
			uiAnim.SetTrigger ("FadeIn");
		}
	}

	public void NextToSMP(){
		blackScreen.SetActive (true);
		camAnim.SetTrigger ("ShowDia");
		uiAnim.SetTrigger ("FadeOut");
	}

	public void ExitIntro(){
		SceneManager.LoadSceneAsync ("Menu");
	}

	int cc=1;
	public void Next(){
		if (cc < msgs.Length) {
			msgTv.text = msgs [cc++];
		}
		camAnim.SetTrigger ("NextClicked");
		StartStone ();
		StartCoroutine ("MyTimer");
	}

	void StartStone(){
		stoneAnim.SetTrigger ("StartFilling");
	}

	IEnumerator MyTimer(){
		int duration= 170;
		nextB.SetActive (false);
		for (int i = 0; i <= duration; i++) {
			if (i == duration) {
				if (cc ==3) {
					continue;
				}
				nextB.SetActive (true);
			}
			yield return null;
		}
	}

}//classEND
