using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public int damage = 10;
	public float bulletSpeed = 5f;
	public Transform bulletEffect;
	private PlayerManager pl;
	int index;
	// Use this for initialization
	void Start () {
		pl = PlayerManager.FindObjectOfType<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (index < 0) {
			transform.Translate (Vector2.left * bulletSpeed * Time.deltaTime);
		}else if(index >= 0){
			transform.Translate (Vector2.right * bulletSpeed * Time.deltaTime);
		}
	}

	public void bulletIndex(int i){
		index = i;
	}

	void OnCollisionEnter2D(Collision2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			if (pl == null)
				return;
			pl.DamagePlayer (damage);
		}
		Transform hitEffect = Instantiate (bulletEffect, transform.position, Quaternion.identity) as Transform;
		Destroy (hitEffect.gameObject, 0.5f);
		Destroy (gameObject);
	}
}
