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

	public GameObject rewardPanel;
	public GameObject gameOver;

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		enemy = GameObject.FindGameObjectWithTag ("Enemy");

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

	}

	void Awake() {
	}

	void Update() {
		player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, 0f);
		enemy.transform.rotation = Quaternion.Euler(enemy.transform.rotation.eulerAngles.x, enemy.transform.rotation.eulerAngles.y, 0f);
		mainCamera.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
	}
}
