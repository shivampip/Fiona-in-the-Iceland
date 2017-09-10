using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonateSri : MonoBehaviour {

	public BankSri bankS;
	public GameObject msgPanel;
	public Text msgTv;
	public Text lifeTv;
	public Transform stoneT;
	public float stoneHight;

	int[] money= new int[]{10,25,40,75,120,150,200,250,300,400,500};

	int GetMoney(){
		Debug.Log ("SStone Proo is " + GetStoneProgress ());
		return money [GetStoneProgress()];
	}

	// Use this for initialization
	void Start () {
		//ResetProgress ();
		UpdateProgress();
		//bankS.AddLifes (2222);
		//bankS.WithdrawLife(900);
		Check ();
	}

	void Check(){
		if (GetStoneProgress () >= 10) {
			Debug.Log ("Done Done Done Done Done Done Done Done Done Done Done Done");
			Enjoy ();
			return;
		}

		if (bankS.GetLifes () < GetMoney()) {
			msgPanel.SetActive (true);
			msgTv.text = "You must have atleast "+GetMoney()+" Lifes to donate. Collect " + (GetMoney() - bankS.GetLifes ()) + " lifes more.";
		} else {
			msgPanel.SetActive (false);
		}
	}

	public int GetStoneProgress(){
		return PlayerPrefs.GetInt ("stoneProgress");
	}

	public void IncrStoneProgress(int amount){
		amount += GetStoneProgress ();
		PlayerPrefs.SetInt ("stoneProgress", amount);
		UpdateProgress ();
	}

	public void ResetProgress(){
		PlayerPrefs.SetInt ("stoneProgress", 0);
	}

	public void UpdateProgress(){
		int amount= GetStoneProgress ();
		float a = (amount / 14.0f) * stoneHight;
		Debug.Log ("Progress is " + GetStoneProgress () + " amount is " + a);
		stoneT.position = new Vector3 (0f, a*-1, 0f);
	}
	

	public void DonateLifes(){
		Debug.Log ("Donating");
		bankS.WithdrawLife (GetMoney());
		IncrStoneProgress (1);
		lifeTv.text = ((int)bankS.GetLifes ()).ToString ();
		Check ();
	}

	void Enjoy(){
		msgPanel.SetActive (true);
		msgTv.text = "Congratulation, Now Nawal is Fine...";
	}

}//classEND
