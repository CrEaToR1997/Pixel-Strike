using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	public float bulletSpeed = 20f;
	public float bulletDamage = 5f;
	private Rigidbody2D rigid2D;
	public Transform bulletHitEnemy;
	public Transform bulletHitTile;
	private EnemyManager enem;
	private CameraShake camShake;
	public bool shakeCamera = false;
	public float ShakeAmount = 2;
	public float ShakeLength = 0.2f;

	void Awake(){
		
	}

	void Start(){
		enem = EnemyManager.FindObjectOfType<EnemyManager> ();
		camShake = CameraShake.FindObjectOfType<CameraShake> ();
	}

	void Update(){
		transform.Translate (Vector3.right * bulletSpeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D cold){
		if (bulletHitEnemy == null) {
			Debug.Log ("Effect prefab not attached");
			return;
		}

		if (cold.gameObject.tag == "Enemy") {
			enem.HealthManager (bulletDamage);
			Transform hitEffect = Instantiate (bulletHitEnemy, gameObject.transform.position, gameObject.transform.rotation) as Transform;
			hitEffect.GetComponent<ParticleSystem> ().Play ();
			Destroy (hitEffect.gameObject, 0.2f);
		}

		if (cold.gameObject.tag == "MyTiles") {
			Transform hit = Instantiate (bulletHitTile, gameObject.transform.position, gameObject.transform.rotation) as Transform;
			hit.GetComponent<ParticleSystem> ().Play ();
			Destroy (hit.gameObject, 0.5f);
		}

		if (shakeCamera) {
			camShake.Shake (ShakeAmount, ShakeLength);
		}
		Destroy (gameObject);
	}
}
