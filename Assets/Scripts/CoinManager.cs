using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	int value;


	public Transform target;
	public float speed = 5f;

	void Start () {
		value = PlayerPrefs.GetInt ("CoinValue");
		target = GameObject.FindWithTag ("MyPlayer").transform;
		ReachTarget ();
	}
	
	void OnTriggerEnter2D(Collider2D cold){
		if (cold.gameObject.tag == "MyPlayer") {
			CoinIncrement (5);
			Debug.Log (value);
			Destroy (gameObject);
		}
	}

	void Update(){
		ReachTarget ();
		value = PlayerPrefs.GetInt ("CoinValue");
	}

	public void CoinIncrement(int n){
		value += n;
		PlayerPrefs.SetInt ("CoinValue", value);
	}
	public void CoinDecrement(int n){
		value -= n;
		PlayerPrefs.SetInt ("CoinValue", value);
	}

	private void ReachTarget(){
		if (target == null) {
			SearchPlayer ();
			return;
		}
		float dist = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, dist);
	}

	void SearchPlayer(){
		if (GameObject.FindWithTag ("MyPlayer")) {
			target =  GameObject.FindWithTag ("MyPlayer").transform;
		}
	}
}
