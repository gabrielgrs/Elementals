using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Text playerName;
	public Text playerLife;
	public Text playerMana;

	public Text enemyName;
	public Text enemyLife;
	public Text enemyMana;

	public GameObject player;
	public PlayerController playerController;
	public PlayerModel playerModel;

	public GameObject enemy;
	public EnemyModel enemyModel;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");

	
		playerModel = player.GetComponent<PlayerModel> ();
		enemyModel = enemy.GetComponent<EnemyModel> ();

	}
	

	void Update () {
		playerName.text = playerModel.Name;
		playerLife.text = playerModel.Life.ToString () + "/" + playerModel.MaxLife.ToString ();
		playerMana.text = playerModel.Mana.ToString () + "/" + playerModel.MaxMana.ToString ();

		enemyName.text = enemyModel.Name;
		enemyLife.text = enemyModel.Life.ToString () + "/" + enemyModel.MaxLife.ToString ();
		enemyMana.text = enemyModel.Mana.ToString () + "/" + enemyModel.MaxMana.ToString ();
	}
}
