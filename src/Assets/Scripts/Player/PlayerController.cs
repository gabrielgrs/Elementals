using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject player;
	public PlayerModel model;
	public GameObject enemy;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		model = player.GetComponent<PlayerModel> ();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	void Update () {
		// print (model.Life);
	}

	public void receiveDamage(int damage) {
		print (model.Life);
		int finalDamage = model.Defense - damage;

		if (finalDamage < 1) {
			finalDamage = 1;
		} 
		
		model.Life -= finalDamage;

		verifyLife ();
	}

	public void verifyLife() {
		if (model.Life < 1) {
			model.Died = true;
			print ("Morto");
		}
	}
}
