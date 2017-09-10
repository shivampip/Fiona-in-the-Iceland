using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManagerSri : MonoBehaviour {

	public AudioClip jumpClip, deathClip, powerUpClip, buttonClickClip;
	public MySound[] sounds;
	public AudioClip[] coinsAc;

	private AudioSource []coinsAs;
	private AudioSource jumpSrc, deathSrc, powerUpSrc, buttonClickSrc;


	// Use this for initialization
	void Awake () {
		coinsAs= new AudioSource[coinsAc.Length];
		for (int i = 0; i < coinsAc.Length; i++) {
			coinsAs[i]= gameObject.AddComponent<AudioSource>();
			coinsAs[i].clip = coinsAc [i];
			coinsAs[i].volume = 0.2f;
			coinsAs[i].pitch = 1f;
		}

		jumpSrc = gameObject.AddComponent<AudioSource> ();
		jumpSrc.clip = jumpClip;
		jumpSrc.volume = 1f;

		deathSrc = gameObject.AddComponent<AudioSource> ();
		deathSrc.clip = deathClip;
		deathSrc.volume = 1f;

		powerUpSrc = gameObject.AddComponent<AudioSource> ();
		powerUpSrc.clip = powerUpClip;
		powerUpSrc.volume = 0.5f;

		buttonClickSrc = gameObject.AddComponent<AudioSource> ();
		buttonClickSrc.clip = buttonClickClip;
		buttonClickSrc.volume = 1f;

		coinCounter = -1;
		foreach (MySound ms in sounds) {
			ms.source = gameObject.AddComponent<AudioSource> ();
			ms.source.clip = ms.clip;
			ms.source.volume = ms.volume;
			ms.source.pitch = ms.pitch;
		}
	}
	
	public void Play(string name){
		MySound ms= Array.Find (sounds, MySound => MySound.name == name);
		ms.source.Play ();
	}

	int coinCounter;
	public void PlayCoinTune(){
		if (coinCounter == coinsAs.Length-1) {
			coinCounter = 0;
		} else {
			coinCounter++;
		}
		coinsAs[coinCounter].Play ();
	}

	public void PlayJump(){
		jumpSrc.Play ();
	}

	public void PlayDeath(){
		deathSrc.Play ();
	}

	public void PlayPowerUp(){
		powerUpSrc.Play ();
	}

	public void PlayButtonClick(){
		buttonClickSrc.Play ();
	}

}//classEND
