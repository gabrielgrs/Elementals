using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Slider SliderHP;
	public Slider SliderMP;

	public Text playerLevel;
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
		SliderHP.maxValue = playerModel.MaxLife;
		SliderMP.maxValue = playerModel.MaxMana;

		SliderHP.value = playerModel.Life;
		SliderMP.value = playerModel.Mana;

		playerLevel.text = playerModel.Level.ToString();
		playerName.text = playerModel.Name;
	}
}
