using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	public Sprite[] lives;
	private int gameIndex ;
	GameObject LifeSprite;
	public Transform reSpawnEffect;
	public Transform playerPrefab;
	public Transform[] spawnPoints;

	void Start(){
		gameIndex = 1;
		LifeSprite = GameObject.Find ("Life");

	}

	public void KillPlayer(GameObject pl){
		MakeEffects (pl);
		Destroy (pl);
		Transform effect = Instantiate (reSpawnEffect, pl.transform.position, pl.transform.rotation);
		Destroy (effect.gameObject, 0.2f);
		gameIndex++;
		if (gameIndex <= 3) {
			StartCoroutine (Delay ());
			LifeSprite.GetComponent<SpriteRenderer> ().sprite = lives [gameIndex - 2];
		} else {
			//gameOver screen
		}
	}
		
	void MakeEffects(GameObject pl){
		
	}

	IEnumerator Delay(){
		Debug.Log ("Waiting for player to respawn");
		yield return new WaitForSeconds (2);
		PlayerRespawn ();
	}

	void PlayerRespawn(){
		Transform sp = spawnPoints [Random.Range (0, spawnPoints.Length - 1)];
		Instantiate (playerPrefab.gameObject, sp.position, sp.rotation) ;
		Transform effect = Instantiate (reSpawnEffect,sp.position, sp.rotation);
		Destroy (effect.gameObject, 0.2f);
	}
}
