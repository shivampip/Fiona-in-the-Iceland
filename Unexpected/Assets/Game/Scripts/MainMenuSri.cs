using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSri : MonoBehaviour {

	public Text highScoreTv;
	public AudioClip bClip;
	public GameObject aboutDia, infoDia;

	AudioSource bAudio;

	// Use this for initialization
	void Start () {
		float highScore = PlayerPrefs.GetFloat ("HighScore");
		highScoreTv.text = ((int)highScore).ToString ();
		bAudio= gameObject.AddComponent<AudioSource>();
		bAudio.clip = bClip;
		bAudio.volume = 0.1f;
		bAudio.pitch = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (aboutDia.activeSelf) {
				aboutDia.SetActive (false);
			}else if(infoDia.activeSelf){
				infoDia.SetActive(false);
			}else{
				Quit ();
			}
		}
	}

	public void startGame(){
		SceneManager.LoadScene ("demo");
	}

	public void goToShop(){
		SceneManager.LoadScene ("CharacterChooser");
	}

	public void goToBro(){
		SceneManager.LoadScene ("Brother");
	}

	public void Quit(){
		Application.Quit ();
	}

	public void ButtonClickSound(){
		bAudio.Play ();
	}
	 
}//classEND
