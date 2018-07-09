using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakbableTiles : MonoBehaviour {

	public Transform coin;
	public float health;
	public Transform tileDamagePrefab;
	public bool isRock = false;

	void OnCollisionEnter2D(Collision2D cold){
		if (cold.gameObject.GetComponent<BulletManager> ()) {
			float damage = cold.gameObject.GetComponent<BulletManager> ().bulletDamage;
			Damage (damage);
		}
	}

	void Damage(float x){
		health -= x;
	}

	void Update(){
		if (health <= 0) {
			Transform tileDamage = Instantiate (tileDamagePrefab, transform.position, transform.rotation);
			if (isRock) {
				tileDamage.GetComponent<ParticleSystem> ().Play ();
				Destroy (tileDamage.gameObject, 0.5f);
				Destroy (gameObject);
			}
			else {
				Instantiate (coin, transform.position, transform.rotation);
				tileDamage.GetComponent<ParticleSystem> ().Play ();
				Destroy (tileDamage.gameObject, 0.5f);
				Destroy (gameObject);
			}

		}
	}
}
