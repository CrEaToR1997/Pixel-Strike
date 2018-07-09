using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSM : MonoBehaviour {

	public Sprite[] img;
	private int[] CostArray = { 0, 50, 70, 120, 200, 400 };
	private int[] gunInventory = new int[6];
	public Image gunImg;
	public Text coinValue;
	public Text cost;
	int x = 0;
	int val;
	int gunCost;

	void Start(){
		val = PlayerPrefs.GetInt ("CoinValue");
		coinValue.text = "Coins : " + val;
	}

	public void SlideLeft(){
		if (x == 0) {
			x = img.Length-1;
		} else {
			x--;
		}
	}

	public void SLideRight(){
		if (x == (img.Length - 1)) {
			x = 0;
		} else {
			x++;
		}
	}

	void defineGunCost(int x){
		gunCost = CostArray [x];
		cost.text = "Cost : " + gunCost;
	}

	public void Buy(){
		if (val >= gunCost) {
			
		} else {
		}
	}

	public void SelectGun(){
		
	}



}
