using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSri : MonoBehaviour {

	private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private bool isDragging= false;
	private Vector2 startTouch, swipeDelta;
	private bool isDeath= false;


	private void Update(){

		if (isDeath) {
			return;
		}

		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

		#region StandAlone Input
		if (Input.GetMouseButtonDown (0)) {
			tap = true;
			isDragging= true;
			startTouch = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			isDragging= false;
			Reset ();
		}
		#endregion

		#region Mobile Input
		if(Input.touches.Length>0){
			if(Input.touches[0].phase==TouchPhase.Began){
				tap= true;
				isDragging= true;
				startTouch= Input.touches[0].position;
			}else if(Input.touches[0].phase==TouchPhase.Ended||Input.touches[0].phase==TouchPhase.Canceled){
				isDragging= false;
				Reset();
			}
		}
		#endregion

		//Calculate the distance
		swipeDelta= Vector2.zero;
		if (isDragging) {
			if (Input.touches.Length > 0) {
				swipeDelta = Input.touches [0].position - startTouch;
			} else if (Input.GetMouseButton (0)) {
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		//Did we cross the dead zone
		if (swipeDelta.magnitude > 125) {
			//Which Direction
			float x= swipeDelta.x;
			float y = swipeDelta.y;

			if (Mathf.Abs (x) > Mathf.Abs (y)) {
				//Left or Ritht
				if (x < 0) {
					swipeLeft = true;
					Debug.Log ("Left");
				} else {
					swipeRight = true;
					Debug.Log ("Right");
				}
			} else {
				//Up or Down
				if (y < 0) {
					swipeDown = true;
					Debug.Log ("Down");
				} else {
					swipeUp = true;
					Debug.Log ("Up");
				}
			}

			Reset ();
		}

	

	}//UpdateEND

	private void Reset(){
		startTouch =swipeDelta = Vector2.zero;
		isDragging = false;
	}


	public Vector2 SwipeDelta{get{return swipeDelta;}}
	public bool SwipeLeft{get{ return swipeLeft;}}
	public bool SwipeRight{get{ return swipeRight;}}
	public bool SwipeUp{get{ return swipeUp;}}
	public bool SwipeDown{get{ return swipeDown;}}


	public void Death(){
		isDeath = true;
	}


}//classEND
