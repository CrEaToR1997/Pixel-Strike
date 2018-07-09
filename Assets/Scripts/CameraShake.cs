using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	float shakeAmnt = 0f;
	Vector3 camPrevPos;

	public void Shake(float amnt, float length){
		shakeAmnt = amnt;
		InvokeRepeating ("ShakeCam", 0, 0.01f);
		Invoke ("StopShake",length);
	}

	void ShakeCam(){
		if (shakeAmnt > 0) {
			camPrevPos = Camera.main.transform.position;
			Vector3 camPos = Camera.main.transform.position;
			float offsetX = Random.value * shakeAmnt * 2 - shakeAmnt;
			float offsetY = Random.value * shakeAmnt * 2 - shakeAmnt;
			camPos.x += offsetX;
			camPos.y += offsetY;
			Camera.main.transform.position = camPos;
		}
	}

	void StopShake(){
		CancelInvoke ("ShakeCam");
		Camera.main.transform.position = camPrevPos;
	}
}
