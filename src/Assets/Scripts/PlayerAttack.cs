using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public bool attacking = false;

	public GameObject player;
	public GameObject enemy;

	public float attackTimer = 0;
	public float attackCoolDown = 0.3f;

	public Collider2D attackTrigger;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	void Awake() {
		attackTrigger.enabled = false;
	}

	void Update() {
		if (Input.GetKeyDown("f") && !attacking) {
			print ("Ataquei!");
			attacking = true;
			attackTimer = attackCoolDown;

			attackTrigger.enabled = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}
	}
}