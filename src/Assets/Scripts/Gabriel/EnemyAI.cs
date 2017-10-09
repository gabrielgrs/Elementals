using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	private GameObject enemy;
	private GameObject player;
	private float range;
	public float speed;

	private float attackTime;
	private float coolDown;




	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		player = GameObject.FindGameObjectWithTag ("Player");

		attackTime = 0;
		coolDown = 2f;
	}

	// Update is called once per frame
	void Update () {
		range = Vector2.Distance (enemy.transform.position, player.transform.position);
		if (range <= 15f) {
			transform.Translate(Vector2.MoveTowards (enemy.transform.position, player.transform.position, range) * speed * Time.deltaTime);
			if (range < 3f) {
				attack ();
			}
		}

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

	void attack() {
		// atacando
		PlayerHealth player = (PlayerHealth)target.GetComponent<PlayerHealth>();
		player.takeDamage (10);
	}
}