using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {
	public GameObject player;
	public PlayerModel playerModel;
	public PlayerController playerController;

	public GameObject enemy;
	public EnemyModel enemyModel;
	public EnemyController enemyController;

	public GameStorage gameStorage;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerModel = player.gameObject.GetComponent<PlayerModel> ();
		playerController = player.gameObject.GetComponent <PlayerController> ();

		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		enemyModel = enemy.gameObject.GetComponent<EnemyModel> ();
		enemyController = enemy.gameObject.GetComponent<EnemyController> ();

		gameStorage = GetComponent<GameStorage> ();
	}

	void Update() {
		if (playerModel.Life < 1) {
			print ("Game Over!");
			gameStorage.saveGame ();
		}

		if (enemyModel.Life < 1) {
			print ("You Win!");
			gameStorage.saveGame ();
		}
	}
}
