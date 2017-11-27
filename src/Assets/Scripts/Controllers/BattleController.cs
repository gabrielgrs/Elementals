using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {
	public GameObject player;
	public PlayerModel playerModel;
	public PlayerController playerController;

	public GameObject enemy;
	public EnemyModel enemyModel;
	public EnemyController enemyController;

	private GameObject mainCamera;

	public GameStorage gameStorage;

	public GameObject rewardPanel;
	public GameObject gameOver;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerModel = player.gameObject.GetComponent<PlayerModel> ();
		playerController = player.gameObject.GetComponent <PlayerController> ();

		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		enemyModel = enemy.gameObject.GetComponent<EnemyModel> ();
		enemyController = enemy.gameObject.GetComponent<EnemyController> ();

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		gameStorage = gameObject.AddComponent<GameStorage> ();
	}

	void Awake() {
		rewardPanel = GameObject.Find ("RewardPanel");
		gameOver = GameObject.Find ("GameOver");	
	}

	void Update() {
		player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, 0f);
		enemy.transform.rotation = Quaternion.Euler(enemy.transform.rotation.eulerAngles.x, enemy.transform.rotation.eulerAngles.y, 0f);
		mainCamera.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);

		if (playerModel.Life < 1) {
			print ("Game Over!");
			gameStorage.saveGame ();
			gameOver.SetActive (true);
		}

		if (enemyModel.Life < 1) {
			print ("You Win!");
			gameStorage.saveGame ();
			rewardPanel.SetActive (true);
		}
	}
}
