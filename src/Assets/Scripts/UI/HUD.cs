using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Slider SliderHP;
	public Slider SliderMP;
	public Slider sliderEnemyLife;

	public Text playerLevel;
	public Text playerName;
	public Text playerLife;
	public Text playerMana;

	public Text enemyName;
	public Text enemyLife;
	public Text enemyMana;

    public Text lifePotionQuantity;
    public Text manaPotionQuantity;

	public GameObject player;
	public PlayerController playerController;
	public PlayerModel playerModel;

	public GameObject enemy;
	public EnemyModel enemyModel;

	public GameObject LifeHUD;

	public GameObject gameOver;
	public GameObject rewardPanel;

	public Text expBonus;
	public Text goldBonus;

	public GameStorage gameStorage;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	
		playerModel = player.GetComponent<PlayerModel> ();
		enemyModel = enemy.GetComponent<EnemyModel> ();
	}

	void Awake() {
		gameStorage = gameObject.AddComponent<GameStorage> ();

		gameOver = GameObject.Find ("GameOver");
		rewardPanel = GameObject.Find ("RewardPanel");
		gameOver.SetActive (false);
		rewardPanel.SetActive (false);
	}
	
	void FixedUpdate() {
		// PlayerHUD
		LifeHUD.transform.position = new Vector2 (Screen.width / 20, Screen.height - 50);
		sliderEnemyLife.transform.position = new Vector2 (Screen.width * 0.9f, Screen.height - 50);

		SliderHP.maxValue = playerModel.MaxLife;
		SliderMP.maxValue = playerModel.MaxMana;

		SliderHP.value = playerModel.Life;
		SliderMP.value = playerModel.Mana;

        playerLevel.text = playerModel.Level != 0 ? (playerModel.Level < 10 ? "0" + playerModel.Level.ToString() : playerModel.Level.ToString()) : "??\t";
		playerName.text = playerModel.Name;

        lifePotionQuantity.text = playerModel.LifePotion.ToString();
        manaPotionQuantity.text = playerModel.ManaPotion.ToString();

		// EnemyHUD
		sliderEnemyLife.maxValue = enemyModel.MaxLife;
		sliderEnemyLife.value = enemyModel.Life;

		if (SliderHP.value < 1) {
			gameOver.SetActive (true);
		}
		if (sliderEnemyLife.value < 1) {
			expBonus.text = "Você ganhou " + enemyModel.ExpBonus.ToString() + " de experiência!";
			goldBonus.text = "Você ganhou " + enemyModel.GoldBonus.ToString() + " de experiência!";
			rewardPanel.SetActive (true);
		}
	}
}
