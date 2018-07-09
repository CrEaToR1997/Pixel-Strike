using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;
	public Camera myCam;
	private float[] parallaxScales;
	private Transform cam;
	private Vector3 previousCamPos;
	public float smoothing = 1;

	void Awake(){
		cam = myCam.transform;
	}

	void Start(){
		previousCamPos = cam.position;
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales [i] = backgrounds [i].position.z * -1;
		}
	}

	void Update(){
		for (int i = 0; i < backgrounds.Length; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales [i];
			float backgroundTargetPos = backgrounds [i].position.x + parallax;
			Vector3 backgroundPos = new Vector3 (backgroundTargetPos, backgrounds [i].position.y, backgrounds [i].position.z);
			backgrounds [i].position = Vector3.Lerp (backgrounds [i].position, backgroundPos, Time.deltaTime * smoothing);
		}

		previousCamPos = cam.position;
	}
}
