using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderSri : MonoBehaviour {

	public GameObject loadingScreen, buttonsUI;
	public Slider slider;

	void Awake(){
		if (IsFirstRun ()) {
			SceneManager.LoadScene ("IntroBro");
		}
	}

	void Start(){
	}

	public void LoadLevel(int sceneIndex){
		StartCoroutine (LoadAsynchronously (sceneIndex));
	}

	IEnumerator LoadAsynchronously(int sceneIndex){
		AsyncOperation operation= SceneManager.LoadSceneAsync (sceneIndex);
		loadingScreen.SetActive (true);
		buttonsUI.SetActive (false);
		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			slider.value = progress;
			yield return null;
		}
	}

	public bool IsFirstRun(){
		int no = PlayerPrefs.GetInt ("isFirst");
		if (no == 7) {
			return false;
		} else {
			PlayerPrefs.SetInt ("isFirst", 7);
			return true;
		}
	}

}//classEND
