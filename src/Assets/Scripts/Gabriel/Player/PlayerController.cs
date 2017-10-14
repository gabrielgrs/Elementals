using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private GameObject player;
	private PlayerModel model;
	private GameObject enemy;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		model = (PlayerModel)player.GetComponent<PlayerModel>();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	void Update () {
		print (model.Life);
	}

	public void receiveDamage(int damage) {
		int finalDamage = model.Defense - damage;

		if (finalDamage < 1) {
			finalDamage = 1;
		} else if (finalDamage > 0) {
			model.Life -= damage;
		}

		verifyLife ();
	}

	private void verifyLife() {
		if (model.Life < 1) {
			model.Died = true;
		}
	}
}
