using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenuSri : MonoBehaviour {

	public Text scoreTv, coinTv, lifeTv;

	public Image background;

	private float transitionDur = 0.0f;
	private bool isShown= false;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShown) {
			return;
		}
		transitionDur += Time.deltaTime;
		background.color = Color.Lerp (new Color (0, 0, 0, 0), new Color(0,0,0,0.5f), transitionDur);
	}

	public void ToggleEndMenu(float score, float coin, float life){
		isShown = true;
		gameObject.SetActive (true);
		scoreTv.text = ((int)score).ToString ();
		coinTv.text = ((int)coin).ToString ();
		lifeTv.text = ((int)life).ToString ();
	}


	public void Restart(){
		Debug.Log ("Resssstaet");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void ToMenu(){
		SceneManager.LoadScene ("Menu");
	}


}//classEND
