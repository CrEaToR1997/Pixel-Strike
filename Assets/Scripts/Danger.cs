using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour {



	void Start(){
		
	}

	void OnTriggerEnter2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			GameObject player = cold.gameObject;
			player.GetComponent<PlayerManager> ().health = -99;
		}
	}
}
