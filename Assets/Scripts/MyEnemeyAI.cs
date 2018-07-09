using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemeyAI : MonoBehaviour {

	public Transform target;
	bool faceLeft = true;
	public float speed = 20f;
	public int scaleValue = 1;
	public ForceMode2D fMode;
	private Rigidbody2D rigid;

	void Start(){
		rigid = GetComponent<Rigidbody2D> ();
		SearchPlayer ();
	}
	void Update(){
		if (target == null) {
			SearchPlayer ();
			return;
		}
		ChaseTarget ();
		LookAtPlayer (scaleValue);
	}

	void ChaseTarget(){
		float dist = speed * Time.deltaTime;
//		Vector3 dir = (transform.position - target.position).normalized;
//		dist *= dir.x;
		transform.position = Vector3.MoveTowards (transform.position, target.position, dist);
//		rigid.AddForce (dir, fMode);
	}

	void SearchPlayer(){
		if (GameObject.FindWithTag ("MyPlayer")) {
			target = GameObject.FindWithTag ("MyPlayer").transform;
		}
	}

	void LookAtPlayer(int n) {
		float myPos = transform.position.x;
		float playerPos = target.position.x;

		if (playerPos < myPos) {
			faceLeft = true;
		}
		else if(playerPos > myPos){
			faceLeft = false;
		}

		if (faceLeft) {
			Vector3 xScale = transform.localScale;
			xScale.x = n;
			transform.localScale = xScale;
		} else {
			Vector3 xScale = transform.localScale;
			xScale.x = -n;
			transform.localScale = xScale;
		}
	}
}
