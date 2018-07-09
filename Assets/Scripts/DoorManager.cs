using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

	public int level;
	public bool isExitDoor = false;
	public bool isDoorLocked = false;
	public Sprite[] doorSprites;
	public int index; // index of door 
	private GameMaster gm;
	private LevelManager lm;
	private int var = 0;
	private bool wasDoorUnlocked = false;

	void Start(){
		gm = GameMaster.FindObjectOfType<GameMaster> ();
		lm = LevelManager.FindObjectOfType<LevelManager> ();
	}

	void Update(){
		if(wasDoorUnlocked){
			return;
		}
		if (index == PlayerPrefs.GetInt ("KeyToDoor")) {
			isDoorLocked = false;
			gameObject.GetComponent<SpriteRenderer> ().sprite = doorSprites [1];
			wasDoorUnlocked = true;

		}
	}

//	void OnTriggerEnter2D(Collider2D cold){
//		if (cold.gameObject.tag == "MyPlayer") {
//			if (isExitDoor) {
//				string myText = "Press E To Open The Door";
//				gm.Display (myText);
//				Debug.Log ("Press E to enter");
//			} else {
//				if (isDoorLocked) {
//					string myText = "Door is Locked, find the key";
//					gm.Display (myText);
//				} else {
//					string myText = "Press E To Open The Door";
//					gm.Display (myText);
//				}
//			}
//		}
//	}

	void OnTriggerStay2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			if (isExitDoor) {
				if (Input.GetKeyDown ("e")){
					Debug.Log ("Door Working");
					lm.LoadLevel (level);
				}
			} else {
				if (!isDoorLocked) {
					if (Input.GetKeyDown ("e")){
						Debug.Log ("Door Working");
						lm.LoadLevel (level);
					}
				}
			}
		}
	}


//	void OnTriggerExit2D(Collider2D cold){
//		if (cold.gameObject.tag == "MyPlayer") {
//			if (isExitDoor) {
//				string myText = " ";
//				gm.Display (myText);
//				Debug.Log ("Press E to enter");
//			} else {
//				if (isDoorLocked) {
//					string myText = " ";
//					gm.Display (myText);
//				} else {
//					string myText = " ";
//					gm.Display (myText);
//				}
//			}
//		}
//	}

}
