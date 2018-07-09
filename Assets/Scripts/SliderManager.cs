using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour {

	public Slider slider;
	float x = 0;
	public float rate = 10f;
	public GameObject panel;

	void Start(){
		slider.value = 0;
	}

	void Update(){
		x += Time.deltaTime / rate;
		slider.value = x;

		if (slider.value >= 1) {
			panel.SetActive (true);
		}
	}
}
