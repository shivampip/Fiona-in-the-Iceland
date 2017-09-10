using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplaySri : MonoBehaviour {

	public BankSri bankS;
	public Text coinTv, lifeTv, distanceTv;

	// Use this for initialization
	void Start () {
		coinTv.text = bankS.GetCoins ().ToString ();
		lifeTv.text = bankS.GetLifes ().ToString ();
		distanceTv.text = bankS.GetDistance ().ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
