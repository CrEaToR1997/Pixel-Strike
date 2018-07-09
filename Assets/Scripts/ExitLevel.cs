using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour {

	LevelManager lvl;

	void Start(){
		lvl = LevelManager.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerExit2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			lvl.LoadAsync (1);
		}
	}


}
