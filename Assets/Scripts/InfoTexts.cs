using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTexts : MonoBehaviour {

	public Text txt;

	void OnTriggerEnter2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			txt.text = "Shoot the boxes to break them";
		}
	}

	void OnTriggerStay2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			txt.text = "Shoot the boxes to break them";
		}
	}

	void OnTriggerExit2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			txt.text = " ";
		}
	}
}
