using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState {
		Spawning,
		Waiting,
		Counting
	};

	[System.Serializable]
	public class Wave{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] wave;
	public Transform[] spawnPoints;

	public int nextWave = 0;
	public float timeBetweenWaves = 5f; 
	public float waveCountDown ;

	private float searchCountDown = 1f;

	public SpawnState spawn = SpawnState.Counting;

	void Start(){
		waveCountDown = timeBetweenWaves;
	}

	void Update(){

		if (spawn == SpawnState.Waiting) {
			if (!IsEnemyAlive ()) {
				WaveCompleted ();
			} else {
				return;
			}
		}
		if (waveCountDown <= 0) {
			if (spawn != SpawnState.Spawning) {
				StartCoroutine (SpawnWave (wave[nextWave]));	
			}
		} else {
			waveCountDown -= Time.deltaTime;
		}
	}

	bool IsEnemyAlive(){
		searchCountDown -= Time.deltaTime;
		if (searchCountDown <= 0) {
			searchCountDown = 1f;
			if (GameObject.FindWithTag ("Enemy") == null){
				return false;
			}
		}
			
			return true;		
	}

	IEnumerator SpawnWave(Wave wv){
		spawn = SpawnState.Spawning;

		for (int i = 0; i < wv.count; i++) {
			SpawnEnemy (wv.enemy);	
			yield return new WaitForSeconds (1f / wv.rate);
		}

		spawn = SpawnState.Waiting;
		yield return false;
	}

	void SpawnEnemy(Transform bot){
		Transform sp = spawnPoints [Random.Range (0, spawnPoints.Length)];
		Instantiate (bot.gameObject, sp.position, sp.rotation);
		Debug.Log ("Enemy spawned" + bot.name);
	}

	void WaveCompleted(){
		spawn = SpawnState.Counting;
		waveCountDown = timeBetweenWaves;
		if (nextWave + 1 <= wave.Length - 1) {
			nextWave = 0;
		} else {
			nextWave++;
		}
	}

}
