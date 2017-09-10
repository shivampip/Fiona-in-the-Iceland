using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	public SwipeSri swipeCon;
	public AudioManagerSri audioMan;
	public AudioSource runAud;
	public GameObject leftDot,rightDot;

	public float fSpeed= 10.0f;
	private float speed = 3.0f;
	public float jumpSpeed = 10.0F;
	public float gravity = 20.0F;


	private Vector3 moveVector;
	private float verticleVelocity = 0.0f;

	private float duration= 7.0f;

	private bool isDead = false;
	private float startTime;

	Animator anim;

	public bool isTurnable;
	int turnDir = 0;
	float turnCount=0f;


	int dir= 1; //1[z], 2[x], 3[-z], 4[-x]

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
		counter = 0f;
		startTime = Time.time;
		leftDot.SetActive (false);
		rightDot.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (isDead) {
			return;
		}

		if (Time.time-startTime < duration) {
			if (Time.time - startTime < duration/2.0) {
				return;
			}
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}

		moveVector = Vector3.zero;

		if (controller.isGrounded) {
			verticleVelocity = -0.5f;
			if (Input.GetKey (KeyCode.Space) || swipeCon.SwipeUp) {
				verticleVelocity = jumpSpeed;

				//anim.SetTrigger ("Jump");
			}
			if (!runAud.isPlaying) {
				runAud.Play ();
			}
		} else {
			if (transform.position.y < -20.0f) {
				Death ();
			}
			if (runAud.isPlaying) {
				runAud.Stop ();
				audioMan.PlayJump ();
			}
		}
		//} else {
			verticleVelocity -= gravity*Time.deltaTime;
		//}

		//Y- Up and Down
		moveVector.y= verticleVelocity;



		float axisIn = 0.0f;

		if (!isTurnable) {
			axisIn = Input.acceleration.x * speed * 7.0f;
			if (Input.acceleration.x == 0) {
				axisIn = Input.GetAxisRaw ("Horizontal") * speed;
			}
		}

		switch (dir) {
		case 1:
			//X- Left and Right
			moveVector.x= axisIn;
			//Z- Forwoard and Backword
			moveVector.z= fSpeed;
			break;
		case 2:
			moveVector.z= axisIn*-1;
			moveVector.x= fSpeed;
			break;
		case 3:
			moveVector.x= axisIn*-1;
			moveVector.z= fSpeed*-1;
			break;
		case 4:
			moveVector.z= axisIn;
			moveVector.x= fSpeed*-1;
			break;
		}

		controller.Move (moveVector* Time.deltaTime); 

		if (counter<20) {
			counter++;
			return;
		}


		if (isTurnable) {
			if (turnCount > 0) {
				leftDot.SetActive (false);
				rightDot.SetActive (false);
				if (turnDir == 1) {
					transform.Rotate (new Vector3 (0f, -90f, 0f));
					dcrDir ();
					counter = 0f;
				} else if (turnDir == -1) {
					transform.Rotate (new Vector3 (0f, 90f, 0f));
					incrDir ();
					counter = 0f;
				}
			}else if (Input.GetKey (KeyCode.LeftArrow) || swipeCon.SwipeLeft) {//Right
				transform.Rotate (new Vector3 (0f, -90f, 0f));
				dcrDir ();
				counter = 0f;
			} else if (Input.GetKey (KeyCode.RightArrow) || swipeCon.SwipeRight) {//Left
				transform.Rotate (new Vector3 (0f, 90f, 0f));
				incrDir ();
				counter = 0f;
			}
		} else {
			if (Input.GetKey (KeyCode.LeftArrow) || swipeCon.SwipeLeft) {//Right
				turnDir= 1;
				turnCount = 3f;
				leftDot.SetActive (true);
				rightDot.SetActive (false);
			} else if (Input.GetKey (KeyCode.RightArrow) || swipeCon.SwipeRight) {//Left
				turnDir= -1;
				turnCount = 3f;
				rightDot.SetActive (true);
				leftDot.SetActive (false);
			}
		}

		turnCount -= Time.deltaTime;
		if (turnCount <= 0) {
			leftDot.SetActive (false);
			rightDot.SetActive (false);
		}
			

		//if (Input.GetMouseButton (0)) {
			//Right
		//	if (Input.mousePosition.x < Screen.width / 2) {
		//		transform.Rotate (new Vector3 (0f, -90f, 0f));
		//		dcrDir ();
		//		counter = 0f;
		//	} else {//left
		//		transform.Rotate (new Vector3 (0f, 90f, 0f));
		//		incrDir ();
		//		counter = 0f;
		//	}
		//}

	}//end





	float counter;


	public void SetSpeed(float modifier){
		fSpeed = fSpeed + modifier;
		Debug.Log ("CSpeed is " + fSpeed);
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



	private void OnControllerColliderHit(ControllerColliderHit hit){
		//Debug.Log ("HHIITT "+hit.collider.tag);
		if (hit.collider.CompareTag ("enemy")) {
			//	Destroy (hit.gameObject);
			//1[z], 2[x], 3[-z], 4[-x]
			switch (dir) {
			case 1:
				if (hit.point.z > transform.position.z + controller.radius) {
					OnCollidedWithEnemy (hit);
				}
				break;
			case 2:
				if (hit.point.x > transform.position.x + controller.radius) {
					OnCollidedWithEnemy (hit);
				}
				break;
			case 3:
				if (hit.point.z < transform.position.z - controller.radius) {
					OnCollidedWithEnemy (hit);
				}
				break;
			case 4:
				if (hit.point.x < transform.position.x - controller.radius) {
					OnCollidedWithEnemy (hit);
				}
				break;
			}
		} else if (hit.collider.CompareTag ("Diamond")) {
			//hit.gameObject.transform.localScale = new Vector3 (2f, 2f, 2f);
			audioMan.PlayCoinTune ();
			Destroy (hit.gameObject);
			GetComponent<ScoreSri> ().incrCoins (1);
		} else if (hit.collider.CompareTag ("Tilak")) {
			audioMan.PlayCoinTune ();
			Destroy (hit.gameObject);
			GetComponent<ScoreSri> ().incrCoins (2);
		} else if (hit.collider.CompareTag ("Rect")) {
			audioMan.PlayCoinTune ();
			Destroy (hit.gameObject);
			GetComponent<ScoreSri> ().incrCoins (5);
		} 
	}



	private void OnCollidedWithEnemy(ControllerColliderHit hit){
		//Destroy (hit.gameObject);
		Death();
	}

	private void Death(){
		isDead = true;
		//swipeCon.enabled = false;
		GetComponent<ScoreSri> ().OnDeath ();
		audioMan.PlayDeath ();
		swipeCon.Death ();
		runAud.Stop ();
		anim.SetTrigger ("Die");
	}

	private void Jump(){
		//anim.SetTrigger ("Jump");
		//controller.Move (Vector3.up * 10.0f * Time.deltaTime);
	}

}//classEND
