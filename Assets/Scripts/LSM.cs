using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSM : MonoBehaviour {

	public Image levelImg;
	public Sprite[] img;
	public Text costOfLevel;
	public Text coinValue;
	private int[] CostArray = { 0, 50, 100, 200, 300};
	int gunCost;
	int x = 0;
	private LevelManager lm;

	void Start(){
		lm = LevelManager.FindObjectOfType<LevelManager> ();
		coinValue = PlayerPrefs.GetInt ("CoinValue");	
	}

	public void SlideLeft(){
		if (x == 0) {
			x = img.Length-1;
		} else {
			x--;
		}

		defineGunCost (x);
	}

	public void SLideRight(){
		if (x == (img.Length - 1)) {
			x = 0;
		} else {
			x++;
		}

		defineGunCost (x);
	}

	public void SelectLevel(){
		int index = x + 2;
		lm.LoadAsync (index);
	}

	void defineGunCost(int x){
		gunCost = CostArray [x];
		costOfLevel.text = "Cost : " + gunCost;
	}

	public void Buy(){
		
	}


	void Update(){
		levelImg.gameObject.GetComponent<Image> ().sprite = img [x];
	}


}
