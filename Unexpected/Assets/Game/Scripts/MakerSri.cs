using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakerSri : MonoBehaviour {

	private WeatherSri weatherSri;
	public PowerUpSri powerSri;
	public GameObject pauseMenu, resumeMenu, deathMenu, demoMenu;
	public AudioSource backAudio;

	//public float sL= 7.6f;
	public float sL= 22.8f;
	public float tL= 3.8f;

	public int blockOnScreen= 7;
	public int minSidhaBlock= 4;

	public GameObject sidha, turn, island;
	public GameObject life;
	public GameObject []powers;
	public GameObject []problems;
	float x,y,z, angle=0.0f;

	int lastType=0; //0-Init, 1-Sidha, 2-Turn
	int dir=1; //1[z], 2[-z], 3[x], 4[-x]

	int lastTurn=0; //1-Left, 2-Right
	int []turns=new int[2];

	//int []path= new int[]{0,0,0,1,0,2,0,0,1,0,0,2,2,0,0};
	List<GameObject> path;
	Dictionary<int, GameObject> islandss;

	private void storeTurn(int a){
		turns [0] = turns [1];
		turns [1] = a;
	}

	private bool isValidTurn(int a){
		return !(turns [0] == turns [1] && turns [0] == a);
	}

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		x = y = z = 0.0f;
		fBlockCount = 0;
		path = new List<GameObject> ();
		islandss = new Dictionary<int, GameObject> ();
		weatherSri = GetComponent<WeatherSri> ();
		turns [0] = 0;
		turns [1] = 0;

		plainForward ();
		plainForward ();
		for (int i = 0; i < blockOnScreen-2; i++) {
			forward ();
		}


	}//startEND
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if ((!deathMenu.activeSelf)&&(!demoMenu.activeSelf)) {
				Pause ();
			}
		}
		sidhaSri ss = path [1].GetComponent<sidhaSri> ();
		if (ss.isVisited) {
			generate ();
		}
	}

	int fBlockCount;
	public void generate(){
		//Debug.Log ("Gen fBlock is " + fBlockCount);
		GameObject pp = path [0];
		int id = pp.GetInstanceID ();
		if (fBlockCount > 0) {
			fBlockCount--;
			Destroy (pp);
			if (islandss.ContainsKey (id)) {
				//Debug.Log ("IID is " + id);
				Destroy (islandss [id]);
			}
			path.RemoveAt (0);
			return;
		}
		int a = getRandom ();
		while (!isValidTurn (a)) {
			a = getRandom ();
		}
		//Debug.Log ("Gen fB is " + a);
		switch (a) {
		case 0:
			forward ();
			break;
		case 1:
			fBlockCount = minSidhaBlock;
			storeTurn (1);
			left ();
			break;
		case 2:
			fBlockCount = minSidhaBlock;
			storeTurn (2);
			right ();
			break;
		}
		Destroy (pp);
		if (islandss.ContainsKey (id)) {
			//Debug.Log ("IID is " + id);
			Destroy (islandss [id]);
		}
		path.RemoveAt (0);
	}


	private void forward(){
		switch (lastType) {
		case 1://pichla sidha tha
			switch (dir) {
			case 1:
				z += sL;
				break;
			case 2:
				x += sL;
				break;
			case 3:
				z -= sL;
				break;
			case 4:
				x -= sL;
				break;
			}
			break;
		case 2://Pichla turn tha
			switch (dir) {
			case 1:
				z += sL / 2 + tL / 2;
				break;
			case 2:
				x += sL / 2 + tL / 2;
				break;
			case 3:
				z -= sL / 2 + tL / 2;
				break;
			case 4:
				x -= sL / 2 + tL / 2;
				break;
			}
			break;
		}

		GameObject go = Instantiate (getProblem()) as GameObject;
		go.transform.position = new Vector3 (x, y, z);
		go.transform.Rotate (new Vector3 (0f, angle, 0f));

		int a = Random.Range (0, 3);
		if (a == 1) {
			GameObject pw = Instantiate (getPower ()) as GameObject;
			pw.transform.position = new Vector3 (x, y, z);
		}

		lastType = 1;
		generateIsland (go.GetInstanceID());
		path.Add (go);
		weatherSri.SetRandomWeather (new Vector3(x,y,z));
	}

	private void plainForward(){
		switch (lastType) {
		case 1://pichla sidha tha
			switch (dir) {
			case 1:
				z += sL;
				break;
			case 2:
				x += sL;
				break;
			case 3:
				z -= sL;
				break;
			case 4:
				x -= sL;
				break;
			}
			break;
		case 2://Pichla turn tha
			switch (dir) {
			case 1:
				z += sL / 2 + tL / 2;
				break;
			case 2:
				x += sL / 2 + tL / 2;
				break;
			case 3:
				z -= sL / 2 + tL / 2;
				break;
			case 4:
				x -= sL / 2 + tL / 2;
				break;
			}
			break;
		}

		GameObject go = Instantiate (sidha) as GameObject;
		go.transform.position = new Vector3 (x, y, z);
		go.transform.Rotate (new Vector3 (0f, angle, 0f));
		lastType = 1;
		generateIsland (go.GetInstanceID());
		path.Add (go);
		//Debug.Log ("At Z: " + z);
		weatherSri.SetRandomWeather (new Vector3(x,y,z));

	}

	private void left(){
		switch (lastType) {
		case 1://Pichla Sidha tha
			switch (dir) {
			case 1:
				z += sL / 2 + tL / 2;
				break;
			case 2:
				x += sL / 2 + tL / 2;
				break;
			case 3:
				z -= sL / 2 + tL / 2;
				break;
			case 4:
				x -= sL / 2 + tL / 2;
				break;
			}
			break;
		case 2://Pichla Turn tha
			switch (dir) {
			case 1:
				z += tL / 2 + tL / 2;
				break;
			case 2:
				x += tL / 2 + tL / 2;
				break;
			case 3:
				z -= tL / 2 + tL / 2;
				break;
			case 4:
				x -= tL / 2 + tL / 2;
				break;
			}
			break;
		}

		angle += 90f;
		incrDir ();
		lastType = 2;

		GameObject go = Instantiate (turn) as GameObject;
		go.transform.position = new Vector3 (x, y, z);
		go.transform.Rotate (new Vector3 (0f, angle+90f, 0f));
		path.Add (go);
		plainForward ();
		for (int i = 0; i < minSidhaBlock-1; i++) {
			forward ();
		}
	}

	private void right(){
		switch (lastType) {
		case 1:
			switch (dir) {
			case 1:
				z += sL / 2 + tL / 2;
				break;
			case 2:
				x += sL / 2 + tL / 2;
				break;
			case 3:
				z -= sL / 2 + tL / 2;
				break;
			case 4:
				x -= sL / 2 + tL / 2;
				break;
			}
			break;
		case 2:
			switch (dir) {
			case 1:
				z += tL / 2 + tL / 2;
				break;
			case 2:
				x += tL / 2 + tL / 2;
				break;
			case 3:
				z -= tL / 2 + tL / 2;
				break;
			case 4:
				x -= tL / 2 + tL / 2;
				break;
			}
			break;
		}

		angle -= 90f;
		dcrDir ();
		lastType = 2;

		GameObject go = Instantiate (turn) as GameObject;
		go.transform.position = new Vector3 (x, y, z);
		go.transform.Rotate (new Vector3 (0f, angle, 0f));
		path.Add (go);
		plainForward ();
		for (int i = 0; i < minSidhaBlock-1; i++) {
			forward ();
		}
	}

	private void incrDir(){
		if (dir == 4) {
			dir = 1;
		} else {
			dir++;
		}
	}

	private void dcrDir(){
		if (dir == 1) {
			dir = 4;
		} else {
			dir--;
		}
	}

	private int getRandom(){
		int a = Random.Range (1, 100);
		if (a % 5 == 0) {
			return 1;
		} else if (a % 4 == 0) {
			return 2;
		} else {
			return 0;
		}
	}

	private void generateIsland(int id){
		int a = Random.Range (0, 10);
		if (a%2 == 0) {
			return;
		} else {
			GameObject go = Instantiate (island) as GameObject;
			float  xx = x, yy = y, zz = z;
			float distance = Random.Range (4.2f, 8.0f);
			if (a <= 5) {//generate at left
				switch (dir) {
				case 1:
				xx -= distance;
					break;
				case 2:
				zz += distance;
					break;
				case 3:
				xx += distance; 
					break;
				case 4:
				zz -= distance;
					break;
				}
			} else {//right
				switch (dir) {
				case 1:
					xx += distance;
					break;
				case 2:
					zz -= distance;
					break;
				case 3:
					xx -= distance; 
					break;
				case 4:
					zz += distance;
					break;
				}
			}
			go.transform.position= new Vector3(xx,yy,zz);
			islandss.Add (id, go);
			//Debug.Log ("ID is " + id);
		}
	}


	private GameObject getProblem(){
		int a = Random.Range (0, problems.Length);
		return problems [a];
	}

	private GameObject getPower(){
		if (Random.Range (0, 100)%5==0) {
			return life;
		}
		int a = Random.Range (0, powers.Length);
		return powers [a];
	}


	bool isPause=false;
	public void Pause(){
		if (isPause) {
			pauseMenu.SetActive (false);
			resumeMenu.SetActive (true);
			Time.timeScale = 1.0f;
			isPause = false;
			powerSri.ResumeTimer ();
			backAudio.UnPause ();
		} else {
			pauseMenu.SetActive (true);
			resumeMenu.SetActive (false);
			Time.timeScale = 0.0f;
			isPause = true;
			powerSri.PauseTimer ();
			backAudio.Pause ();
		}
	}


}//classEND
