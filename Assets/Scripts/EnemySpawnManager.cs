using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {
	[System.Serializable]
	public class Wave
	{
		public string name;
		public int count;
		public int rate;
		public Transform enemyPrefab;
	}
	public enum SpawnState
	{
		SPAWNING, WAITING
	};
	public Wave[] waves;
	private bool isTriggerd = false;

	public int nextWave = 0;

	private SpawnState state = SpawnState.WAITING;
	void Start(){
		
	}

	void Update(){
		if (isTriggerd && nextWave<waves.Length) {
			if (state != SpawnState.SPAWNING) {
				state = SpawnState.SPAWNING;
				StartCoroutine (SpawnWave (waves [nextWave]));
			}

		}
//		if (nextWave >= waves.Length) {
//			isTriggerd = false;
//		}
	}

	void OnTriggerEnter2D(Collider2D cold){
		if (cold.gameObject.GetComponent<PlayerManager> () && !isTriggerd) {
			Debug.Log ("Player has hit the collider");
			isTriggerd = true;

		}
	}

	IEnumerator SpawnWave(Wave _wave){
		for (int i = 0; i < _wave.count; i++) {
			Debug.Log ("First enemy passed");
			SpawnEnemy (_wave);
			yield return new WaitForSeconds (1 / _wave.rate);
		}
		nextWave++;
		state = SpawnState.WAITING;
		Debug.Log("Spawn state changed");
		yield break;
	}

	void SpawnEnemy(Wave _wave){
		Debug.Log ("Spawning Enemy");
		Instantiate (_wave.enemyPrefab, transform.position, transform.rotation) ;
	}
}
