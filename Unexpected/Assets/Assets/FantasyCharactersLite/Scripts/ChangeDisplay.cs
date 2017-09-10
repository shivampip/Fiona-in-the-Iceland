using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Change a character animations, textures, classes and weapons for the demo
 **/
public class ChangeDisplay : MonoBehaviour {

	public Animator characterAnimator;
	public Texture[] characterTextures;
	public string[] characterAnimations;

	public GameObject[] classes;
	public Texture[] defaultClassesTextures;
	public Texture[] alternativeClassesTextures;

	public GameObject[] weapons;


	private int currentCharTexture = 0;
	private Renderer rend;
	private int currentCharAnim = 0;
	private int currentClass = 0;
	private int currentClassTexture = 0;
	private int currentWeapon = 0;
	private Vector3 defaultPos;

	void Start () {
		rend = GetComponent<Renderer>();
		defaultPos = transform.parent.position;
		changeCharacterTexture ();
		changeCharacterAnimations();
		changeClass ();
		changeClassTexture ();
		changeWeapon();

	}




	void Update () {
		if (Input.GetKeyDown ("space")) {
//			changeCharacterTexture ();
//			changeCharacterAnimations();
			changeWeapon();
		}
		if (Input.GetKeyDown ("end")) {
			//			changeCharacterTexture ();
			//			changeCharacterAnimations();
			changeClass();
		}
	}

	public void changeWeapon() {
		for (int i = 0; i < weapons.Length; i++) {
			if(weapons [i] != null)
				weapons [i].SetActive (i == currentWeapon);
		}
		currentWeapon++;
		if(currentWeapon >= weapons.Length) {
			currentWeapon = 0;
		}	
	}


	public void changeClassTexture() {
		Renderer childRnd;
		for (int i = 0; i < classes.Length; i++) {

			for (int j = 0; j < classes [i].transform.childCount; j++) {
				childRnd = classes [i].transform.GetChild (j).gameObject.GetComponent<Renderer> ();
				if (childRnd != null) {
					if (currentClassTexture == 0) {
						childRnd.material.mainTexture = defaultClassesTextures[i];
					} else {
						childRnd.material.mainTexture = alternativeClassesTextures[i];
					}

				}
			}

		}
		if (currentClassTexture == 0) {
			currentClassTexture = 1;
		} else {
			currentClassTexture = 0;
		}
	}

	public void changeClass() {
		for (int i = 0; i < classes.Length; i++) {
			classes [i].SetActive (i == currentClass);
		}
		currentClass++;
		if(currentClass >= classes.Length) {
			currentClass = 0;
		}	
	}

	public void changeCharacterTexture() {
		rend.material.mainTexture = characterTextures[currentCharTexture++];
		if(currentCharTexture >= characterTextures.Length)
		{
			currentCharTexture = 0;
		}
	}

	public void changeCharacterAnimations() {
		transform.parent.transform.position = defaultPos;
		characterAnimator.Play (characterAnimations[currentCharAnim++]);
		if(currentCharAnim >= characterAnimations.Length)
		{
			currentCharAnim = 0;
		}
	}
}
