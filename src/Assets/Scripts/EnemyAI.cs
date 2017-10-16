using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public GameObject enemy;
	public GameObject player;
	public float range;
	public float speed;

	public float attackTime;
	public float coolDown;

	public PlayerController playerController;


	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerController = player.GetComponent<PlayerController> ();


		range = 10f;
		speed = 0;
		attackTime = 0.5f;
		coolDown = 2f;
	}

	// Update is called once per frame
	void Update () {
		attackVerify ();
	}

	public void attackVerify () {
		range = Vector2.Distance (enemy.transform.position, player.transform.position);
		if (range <= 15f) {
			transform.Translate(Vector2.MoveTowards (enemy.transform.position, player.transform.position, range) * speed * Time.deltaTime);
			if (range < 3f) {
				// AttackTime
				if (attackTime > 0) {
					attackTime -= Time.deltaTime;
				} 
				if (attackTime < 0) {
					attackTime = 0;
				} 
				if (attackTime == 0) {
					attack();
				}	 
			}
		}
	}

	public void attack() {
		// PlayerController player = (PlayerController)target.GetComponent<PlayerController>();
		playerController.receiveDamage (10);
	}
}