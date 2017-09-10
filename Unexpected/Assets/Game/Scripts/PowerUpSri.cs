using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSri : MonoBehaviour {

	public Transform playerT;
	public AudioManagerSri audioSri;
	public int duration;
	public PlayerMotor pm;
	public BankSri bankS;
	public ScoreSri scoreS;
	public GameObject powerBar;
	public Slider slider;
	public AudioSource backAudio;

	private float fastSpeed= 10.0f;
	private float slowSpeed= 5.0f;
	private float highJumpSpeed= 10.0f;
	private float fastPitch = 1.0f;
	private float slowPitch = 0.3f;
	private Vector3 giantFector= new Vector3(0.7f,0.7f,0.7f);
	private Vector3 antFector= new Vector3(0.7f,0.7f,0.7f);


	// Use this for initialization
	void Start () {
		
	}
	
	private void OnControllerColliderHit(ControllerColliderHit hit){
		if (hit.collider.CompareTag ("power")) {
			Destroy (hit.gameObject);
			string name = hit.collider.name;
			StartCoroutine ("MyTimer", name);
			audioSri.PlayPowerUp ();
		} else if (hit.collider.CompareTag ("life")) {
			Destroy (hit.gameObject);
			audioSri.PlayPowerUp ();
			scoreS.incrLifes (1);
		}
	}

	private void OnStart(string power){
		switch (power) {
		case "fast":
			pm.fSpeed += fastSpeed;
			backAudio.pitch += fastPitch;
			break;
		case "slow":
			pm.fSpeed -= slowSpeed;
			backAudio.pitch -= slowPitch;
			break;
		case "highjump":
			pm.jumpSpeed += highJumpSpeed;
			break;
		case "giant":
			//playerT.localScale += giantFector;
			StartCoroutine("ScaleOverTime", playerT.localScale+giantFector);
			break;
		case "ant":
			//playerT.localScale -= antFector;
			StartCoroutine("ScaleOverTime", playerT.localScale-antFector);
			break;
		}
	}

	private void OnStop(string power){
		switch (power) {
		case "fast":
			pm.fSpeed -= fastSpeed;
			backAudio.pitch -= fastPitch;
			break;
		case "slow":
			pm.fSpeed += slowSpeed;
			backAudio.pitch += slowPitch;
			break;
		case "highjump":
			pm.jumpSpeed -= highJumpSpeed;
			break;
		case "giant":
			//playerT.localScale -= giantFector;
			StartCoroutine("ScaleOverTime", playerT.localScale-giantFector);
			break;
		case "ant":
			//playerT.localScale += antFector;
			StartCoroutine("ScaleOverTime", playerT.localScale+antFector);
			break;
		}
	}

	IEnumerator MyTimer(string power){
		powerBar.SetActive (true);
		OnStart (power);
		for (int i = 0; i <= duration; i++) {
			while (isPaused) {
				yield return new WaitForSeconds (0.1f);
			}
			float progress = (float)(duration - i) / (float)duration;
			//Debug.Log ("Progress is " + progress);
			slider.value = progress;
			if (i == duration) {
				OnStop (power);
				powerBar.SetActive (false);
			}
			yield return null;
		}
	}

	IEnumerator ScaleOverTime(Vector3 destination){
		float time= 0.5f;
		Vector3 originalScale = playerT.localScale;
		Vector3 destinationScale = destination;
		float currentTime = 0.0f;
		do{
			playerT.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);
	}

	private bool isPaused=false;
	public void PauseTimer(){
		isPaused = true;
	}

	public void ResumeTimer(){
		isPaused = false;
	}

}//classEND
