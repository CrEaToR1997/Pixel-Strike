using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

	public float healthOfEnem = 20f;
	public static float health;
	public int damage = 5;
	public Transform deathEffectPrefab;
	public Transform moneyPrefab;
	public int coinValue = 5;
	private CoinManager cm;
	public bool isFlying = false;

	float iHealth;
	public Image healthBar;

	private float prev_posX;
	private float xPos;

	public bool isStatic = false;
	public Transform bulletPrefab;
	public int rate = 3;
	private float time = 0;
	PlayerManager pl;

	void Awake(){
		health = healthOfEnem;
	}

	void Start(){
		cm = moneyPrefab.gameObject.GetComponent<CoinManager> ();
		pl = PlayerManager.FindObjectOfType<PlayerManager> ();
		prev_posX = transform.position.x;
		iHealth = health;
	}
		

	public void HealthManager(float n){
		health -= n;
		float reduce = health / iHealth;
		if (reduce < 0.5f) {
			healthBar.color = Color.red;
		}
		healthBar.rectTransform.localScale = new Vector3 (reduce, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z); 

		if (health < 0) {
			Transform deathEffect = Instantiate (deathEffectPrefab, transform.position, transform.rotation) as Transform;
			Transform money = Instantiate (moneyPrefab, transform.position, transform.rotation) as Transform;
			cm.CoinIncrement (coinValue);
			deathEffect.GetComponent<ParticleSystem> ().Play ();
			Destroy (deathEffect.gameObject, 2f);
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			Debug.Log ("Player Collided");
			pl.DamagePlayer (damage);
			Debug.Log ("Player is Being Damaged");
			Destroy (gameObject);
			Transform deathEffect = Instantiate (deathEffectPrefab, transform.position, transform.rotation) as Transform;
			Destroy (deathEffect.gameObject, 1f);
		}
	}
		

	void Update(){
		if (isStatic) {
			time += Time.deltaTime;
			if (time >= rate) {
				StartCoroutine (SpawnBullets (-1));
				StartCoroutine (SpawnBullets (1));
				time = 0;
			}

		}

		if (pl == null) {
			pl = PlayerManager.FindObjectOfType<PlayerManager> ();
		}
	}

	IEnumerator SpawnBullets(int i){
		yield return new WaitForSeconds (1f);
		Transform bullet = Instantiate (bulletPrefab, transform.position, Quaternion.identity) as Transform;
		bullet.GetComponent<EnemyBullet> ().bulletIndex (i);
		Destroy (bullet.gameObject, 3f);
	}



}
