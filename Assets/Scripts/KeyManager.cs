using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

	public int indexOfKey ;
	private GameMaster gm;

	void Start(){
		gm = GameMaster.FindObjectOfType<GameMaster> ();
	}


//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.gameObject.tag == "MyPlayer") {
//			string myText = "You found key no : " + indexOfKey.ToString ();
//			gm.Display (myText);
//			PlayerPrefs.SetInt ("KeyToDoor", indexOfKey); // change pref name on test and deployment
//			Destroy (gameObject);
//		}
//	}
}
