using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	public float health = 100f;
	LevelManager lvl;
	public Text txt;
	int value = 0;
	public Image healthBar;
	float iHealth;
	GameMaster gmObj;

	BulletManager bp;
	GameObject gun;

	void Start(){
		gun = GameObject.Find ("Gun");
		bp = BulletManager.FindObjectOfType<BulletManager> ();
		gmObj = GameMaster.FindObjectOfType<GameMaster> ();
		lvl = LevelManager.FindObjectOfType<LevelManager> ();
		txt = GameObject.Find ("ScoreSheet").GetComponent<Text> ();
		txt.text = "Score: "+value.ToString ();
		iHealth = health;
	}
	void Update(){
		if (health < 0) {
			lvl.LoadAsync (1);
		}
		if (txt == null) {
			txt = GameObject.Find ("ScoreSheet").GetComponent<Text> ();
		}

	}

	public void DamagePlayer(int d){
		health -= d;
		float reduce = health / iHealth;
		if (reduce < 0.5f) {
			healthBar.color = Color.red;
		}
		healthBar.rectTransform.localScale = new Vector3 (reduce, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z); 

		if (health <= 0) {
			gmObj.KillPlayer (gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D cold){
		if (cold.gameObject.GetComponent<CoinManager> ()) {
			value += 5;
			txt.text = "Score: "+value.ToString ();
		}
	}

	void OnCollisionEnter2D(Collision2D cold){

		if (cold.gameObject.tag != "MyTiles") {
			if (cold.gameObject.tag == "MG") {
				ChangeGunSprite (cold.gameObject);
				MoveFirePoint (cold.gameObject, 1.28f, 0.15f);

			
			
			} else if (cold.gameObject.tag == "Shotgun") {
				ChangeGunSprite (cold.gameObject);
				MoveFirePoint (cold.gameObject, 0.958f, 0.148f);
		
			} else if (cold.gameObject.tag == "Bazooka") {
				ChangeGunSprite (cold.gameObject);
				MoveFirePoint (cold.gameObject, 1.621f, 0.028f);
		
			} else if (cold.gameObject.tag == "Assault") {
				ChangeGunSprite (cold.gameObject);
				MoveFirePoint (cold.gameObject, 0.92f, 0.15f);
		
			} else if (cold.gameObject.tag == "Grenade Launcher") {
				ChangeGunSprite (cold.gameObject);
				MoveFirePoint (cold.gameObject, 1.621f, 0.028f);
		
			} else if (cold.gameObject.tag == "SMG") {
				ChangeGunSprite (cold.gameObject);
				MoveFirePoint (cold.gameObject, 0.851f, 0.25f);
			
			}

//			Destroy (cold.gameObject,5f);
		}
	}

	void ChangeGunSprite(GameObject gm){
		gun.GetComponent<SpriteRenderer> ().sprite = gm.GetComponent<SpriteRenderer> ().sprite;
	}

	void MoveFirePoint(GameObject gm, float xPos, float yPos){
//		xPos += gun.GetComponent<Transform> ().position.x;
//		yPos += gun.GetComponent<Transform> ().position.y;
		Vector3 newFirePos =  new Vector3 (xPos, yPos, 0);
	
		gun.GetComponent<Weapon> ().firePoint.position = newFirePos;

	}
}
