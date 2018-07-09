using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			// destroy gameobject and add gun to inventory
		}
	}
}
