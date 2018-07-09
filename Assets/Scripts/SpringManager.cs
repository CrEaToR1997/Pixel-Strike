using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManager : MonoBehaviour {

	Animator anim;
	public float yVel = 1000f;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D cold){
		if (cold.collider.tag == "MyPlayer") {
			StartCoroutine (SetSpring (cold.gameObject));
		}
	}

	IEnumerator SetSpring(GameObject obj){
		anim.SetBool ("Colliding",true);
		Rigidbody2D rigid = obj.GetComponent<Rigidbody2D> ();
		rigid.AddForce (new Vector2 (0f, 0.5f));
		yield return new WaitForSeconds (0.2f);
		anim.SetBool ("Colliding", false);
		rigid.AddForce (new Vector2 (0f, yVel));

	}
}
