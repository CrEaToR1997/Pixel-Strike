using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnlargeImage : MonoBehaviour {

	Transform pic;
	public Text txt;
	public int size;
	Vector3 scale;
	bool isEnlarged = false;

	void Start(){
		pic = transform.Find ("Pic");
	}

	void OnTriggerEnter2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			txt.text = "Press e to enlarge the image";
		}
	}

	void OnTriggerStay2D(Collider2D cold){
		if (Input.GetKeyDown ("e") && !isEnlarged && cold.gameObject.tag == "MyPlayer") {
			txt.text = " ";
			scale = pic.localScale;
			scale.x += size;
			scale.y += size;
			pic.localScale = scale;
			isEnlarged = true;
		}
	}

	void OnTriggerExit2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			txt.text = " ";
			if (isEnlarged) {
				isEnlarged = false;
				scale = pic.localScale;
				scale.x -= size;
				scale.y -= size;
				pic.localScale = scale;
			}
		}
	}
}
