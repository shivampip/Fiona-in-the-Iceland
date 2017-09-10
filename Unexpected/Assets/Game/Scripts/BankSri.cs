using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankSri : MonoBehaviour {

	private int coins, lifes, distance;

	// Use this for initialization
	void Start () {
		GetCoins ();
		GetLifes ();
		GetDistance ();
	}


	public int GetCoins(){
		coins = PlayerPrefs.GetInt ("coins");
		return coins;
	}

	public int GetLifes(){
		lifes = PlayerPrefs.GetInt ("lifes");
		return lifes;
	}

	public int GetDistance(){
		distance = PlayerPrefs.GetInt ("distance");
		return distance;
	}

	public void AddCoins(int newC){
		coins += newC;
		PlayerPrefs.SetInt ("coins", coins);
	}

	public void AddLifes(int newL){
		lifes += newL;
		PlayerPrefs.SetInt ("lifes", lifes);
	}

	public void AddDistance(int newD){
		distance += newD;
		PlayerPrefs.SetInt ("distance", distance);
	}

	public void WithdrawCoins(int newC){
		coins -= newC;
		PlayerPrefs.SetInt ("coins", coins);
	}

	public void WithdrawLife(int newL){
		lifes -= newL;
		PlayerPrefs.SetInt ("lifes", lifes);
	}




}//classEND
