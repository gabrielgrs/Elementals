using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform target;
	public GameObject enemy;
	public GameObject player;
	public float range;
	public float speed;

	public float AttackTime;
	public float coolDown;


	public EnemyFactory enemyFactory;
	public EnemyModel enemyModel;

	public PlayerController playerController;
	public PlayerModel playerModel;
	public PlayerFactory playerFactory;
	


	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		player = GameObject.FindGameObjectWithTag ("Player");

		enemyModel = enemyFactory.generateEnemy();

		// playerModel = player.gameObject.GetComponent<PlayerModel>();
		playerModel = playerFactory.generatePlayer();
		playerController = player.GetComponent<PlayerController> ();


		range = 10f;
		speed = 0;
		AttackTime = 0.5f;
		coolDown = 2f;
	}

	// Update is called once per frame
	void Update () {
		attackVerify ();
	}

	void Attack() {
		// playerController.receiveDamage (playerModel.Attack);
	}

	public void attackVerify () {
		range = Vector2.Distance (enemy.transform.position, player.transform.position);
		if (range <= 15f) {
			transform.Translate(Vector2.MoveTowards (enemy.transform.position, player.transform.position, range) * speed * Time.deltaTime);
			if (range < 3f) {
				// AttackTime
				if (AttackTime > 0) {
					AttackTime -= Time.deltaTime / 2;
				} 
				if (AttackTime < 0) {
					AttackTime = 0;
				} 
				if (AttackTime == 0) {
					Attack();
				}	 
			}
		}
	}


}