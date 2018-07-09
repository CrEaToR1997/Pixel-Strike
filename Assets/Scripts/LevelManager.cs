using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(int n){
		SceneManager.LoadScene (n);
	}

	public void LoadLevel(string n){
		SceneManager.LoadScene (n);
	}

	public void LoadAsync(int index){
		StartCoroutine (LoadLevelAync (index));
	}

	IEnumerator LoadLevelAync(int index){
		AsyncOperation operation = SceneManager.LoadSceneAsync (index);
		while(!operation.isDone){
			double progress = Mathf.Clamp01(operation.progress / 0.9f);
			yield return null;
		}
	}
}
