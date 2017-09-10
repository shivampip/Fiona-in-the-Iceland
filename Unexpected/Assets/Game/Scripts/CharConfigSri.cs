using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharConfigSri : MonoBehaviour {

	public bool isAdvanced;
	public GameObject character;
	public GE_OrbitCamera camControlSri;
	public BankSri bankS;
	public Text buttonTv;
	public Image lockIv;
	public Image msgPanel;
	public Text msgTv;
	public RawImage dialog;

	public CharSri []myChars;

	int cDistance;
	bool isDialogOpened=false;

	// Use this for initialization
	void Start () {
		if (isAdvanced) {
			ResetCharAll ();
			//bankS.AddCoins (30000);
			Purchase (0);
			cDistance = PlayerPrefs.GetInt ("distance");
			dialog.gameObject.SetActive (false);
		}
		RetriveTexture ();
	}


	int counter;
	public void GoLeft(){
		if (isDialogOpened) {
			return;
		}
		if (counter == 0) {
			counter = myChars.Length-1;
		} else {
			counter--;
		}
		UpdateUI ();
	}

	public void GoRight(){
		if (isDialogOpened) {
			return;
		}
		if (counter == myChars.Length-1) {
			counter = 0;
		} else {
			counter++;
		}
		UpdateUI ();
	}

	int bAction=0;
	public void ButtonAction(){
		if (isDialogOpened) {
			return;
		}
		switch (bAction) {
		case 0://Locked
			LockedAction();
			break;
		case 1://Purchase
			Purchase(counter);
			break;
		case 2://Apply
			Apply(counter);
			break;
		case 3://Applied

			break;
		}
	}

	private void Apply(int id){
		PlayerPrefs.SetInt ("texture", id);
		GoBack ();
	}

	private bool IsApplied(int id){
		if (PlayerPrefs.GetInt ("texture") == id) {
			return true;
		}
		return false;
	}

	private void LockedAction(){

	}

	private void RetriveTexture(){
		counter = PlayerPrefs.GetInt ("texture");
		if (!IsBought (counter)) {
			counter = 0;
		}
		if (character != null) {
			character.GetComponent<Renderer> ().material.SetTexture ("_MainTex", myChars [counter].texture);
		}
		UpdateUI ();
	}

	public void GoBack(){
		SceneManager.LoadScene ("Menu");
	}

	public bool IsUnlocked(int id){
		if (myChars [counter].unlockDistance <= cDistance) {
			return true;
		}
		return false;
	}

	public bool IsBought(int id){
		if(PlayerPrefs.GetInt ("char" + id + "purchase")== 1 ){
			return true;
		}
		return false;
	}

	public int Price(int id){
		return myChars [id].price;
	}

	public void Purchase(int id){
		Debug.Log ("Purchasing");
		if (bankS.GetCoins () < myChars [counter].price) {
			Debug.Log ("Not enough money");
			dialog.gameObject.SetActive (true);
			isDialogOpened = true;
			camControlSri.enabled = false;
			return;
		} else {
			bankS.WithdrawCoins (myChars [counter].price);
			PlayerPrefs.SetInt ("char" + id + "purchase", 1);
			UpdateUI ();
			Debug.Log ("Purchesed");
		}
	}

	private void ResetChar(int id){
		PlayerPrefs.SetInt ("char" + id + "purchase", 0);
		if (IsApplied (id)) {
			PlayerPrefs.SetInt ("texture", id);
		}
	}

	public void ResetCharAll(){
		for (int i = 0; i < myChars.Length - 1; i++) {
			ResetChar (i);
		}
	}

	public void removeDialog(){
		dialog.gameObject.SetActive (false);
		camControlSri.enabled = true;
		isDialogOpened = false;
	}

	//public void Unlock(int id){
	//	PlayerPrefs.SetInt ("char" + id + "unlock", 1);
	//}


	private void UpdateUI(){
		if (!isAdvanced) {
			return;
		}
		if (character != null) {
			character.GetComponent<Renderer> ().material.SetTexture ("_MainTex", myChars [counter].texture);
		}if (IsUnlocked (counter)) {
			if (lockIv != null) {
				lockIv.enabled = false;
			}
			camControlSri.enabled = true;
			msgPanel.enabled = false;
			msgTv.enabled = false;
			if (IsBought (counter)) {
				if (IsApplied (counter)) {
					bAction = 3;
					buttonTv.text = "Applied";
				} else {
					bAction = 2;
					buttonTv.text = "Apply";
				}
			} else {
				bAction = 1;
				buttonTv.text = "$"+Price (counter);
			}
		}else{
			bAction = 0;
			if (lockIv != null) {
				lockIv.enabled = true;
			}
			msgPanel.enabled = true;
			msgTv.enabled = true;
			msgTv.text = "You must have travel experience of atleast "+(myChars[counter].unlockDistance)+" meters to Unlock it.";
			buttonTv.text= "Locked";
			camControlSri.enabled = false;
		}
	}

	public void GoToBroIntro(){
		SceneManager.LoadScene ("IntroBro");
	}

}//classEND
