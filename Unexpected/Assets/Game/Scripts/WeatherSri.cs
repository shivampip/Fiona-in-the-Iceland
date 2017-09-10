using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSri : MonoBehaviour {

	public GameObject[] list;
	public int minTimes = 5;
	public bool isEnable;

	// Use this for initialization
	void Start () {
		counter = 0;
		prev = GetRandom ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SetRandomWeather(Vector3 pos){
		if (!isEnable) {
			return;
		}
		GameObject go= Instantiate (getWeather()) as GameObject;
		go.transform.position = pos;
	}

	int counter;
	int prev;
	private GameObject getWeather(){
		if (counter < minTimes) {
			counter++;
		} else {
			counter = 0;
			prev = GetRandom ();
		}
		return list [prev];
	}

	private int GetRandom(){
		return Random.Range (0, list.Length);
	}

}//classEND
