using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBox : MonoBehaviour {

	public float health = 50;
	public BulletManager blt;
	float damage;
	public GameObject specials;
	public Transform destroyEffect;

	public Transform[] special;
	public int specialIndex;
	public Transform textElement;

	void Start(){
		damage = blt.bulletDamage;
	}

	void Update(){
		if (health <= 0) {
			Destroy (textElement.gameObject);
			Transform destroy = Instantiate (destroyEffect, transform.position, transform.rotation);
			destroy.GetComponent<ParticleSystem> ().Play ();
			Destroy (destroy.gameObject, 1);
			Destroy (gameObject);
			Instantiate (special [specialIndex], transform.position, transform.rotation);
		}
	}

	void OnCollisionEnter2D(Collision2D cold){
		if (cold.gameObject.tag == "Bullet") {
			health -= damage;
		}
	}

}
