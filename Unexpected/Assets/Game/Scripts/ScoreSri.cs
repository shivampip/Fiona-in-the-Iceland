using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSri : MonoBehaviour {

	public BankSri bankS;
	public Text disTv, coinTv, lifeTv;
	public DeathMenuSri deathSri;
	public GameObject pauseB;
	public AudioSource backAudio;
	public AudioSource sadAudio;
	private float score= 0.0f;
	private int coins = 0;
	private int lifes= 0;

	private float difficultLevel = 1;
	private float maxDifficultLevel= 10;
	private float scoreToNext = 10;

	private bool isDead = false;



	// Use this for initialization
	void Start () {
		disTv.text = "0";
		coinTv.text = coins.ToString ();
		lifeTv.text = lifes.ToString ();
	}

	// Update is called once per frame
	void Update () {
		if (isDead) {
			return;
		}
		if (score >= scoreToNext) {
			LevelUp ();
		}
		score += Time.deltaTime * difficultLevel; 
		disTv.text = ((int)score).ToString ();
	}


	void LevelUp(){
		if (difficultLevel >= maxDifficultLevel) {
			return;
		}
		scoreToNext *= 1.7f;
		difficultLevel+=0.2f;
		GetComponent<PlayerMotor> ().SetSpeed (.2f);
	}

	public void OnDeath(){
		isDead = true;
		pauseB.SetActive (false);
		backAudio.Stop ();
		sadAudio.Play ();
		if (score > PlayerPrefs.GetFloat ("HighScore")) {
			PlayerPrefs.SetFloat ("HighScore", score);
		}
		bankS.AddCoins ((int)coins);
		bankS.AddDistance ((int)score);
		bankS.AddLifes ((int)lifes);
		deathSri.ToggleEndMenu (score, coins, lifes);
	}

	public void incrCoins(int a){
		coins += a;
		coinTv.text = coins.ToString ();
	}

	public void incrLifes(int a){
		lifes += a;
		lifeTv.text = lifes.ToString ();
	}




}//classEND
