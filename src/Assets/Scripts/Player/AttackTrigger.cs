using UnityEngine;
using System.Collections;


public class AttackTrigger : MonoBehaviour {
	public GameObject player;
	public PlayerModel playerModel;

	public int damage;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerModel = player.gameObject.GetComponent<PlayerModel> ();
		damage = playerModel.Attack;

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.isTrigger != true && col.CompareTag ("Enemy")) {
			// Valida dano no inimigo
		}
			
	}
}