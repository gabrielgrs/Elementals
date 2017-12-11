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

	public int counter;


	void Start () {
		counter = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	
		playerModel = player.GetComponent<PlayerModel> ();
		enemyModel = enemy.GetComponent<EnemyModel> ();

		playerModel.Level = PlayerPrefs.GetInt ("PlayerLevel");
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

 
		playerLevel.text = PlayerPrefs.GetInt ("PlayerLevel") < 10 ? "0" + PlayerPrefs.GetInt ("PlayerLevel").ToString () : "??";
		playerName.text = PlayerPrefs.GetString("PlayerName");

		lifePotionQuantity.text = PlayerPrefs.GetInt("LifePotion").ToString();
		manaPotionQuantity.text = PlayerPrefs.GetInt("ManaPotion").ToString();

		// EnemyHUD
		sliderEnemyLife.maxValue = enemyModel.MaxLife;
		sliderEnemyLife.value = enemyModel.Life;

		if (SliderHP.value < 1) {
			gameOver.SetActive (true);
		}
		if (sliderEnemyLife.value < 1) {

			if (PlayerPrefs.GetInt ("LastStage") == 1) {
				enemyModel.ExpBonus = 10;
				enemyModel.GoldBonus = 10;
			}

			if (PlayerPrefs.GetInt ("LastStage") == 2) {
				enemyModel.ExpBonus = 20;
				enemyModel.GoldBonus = 20;
			}

			if (PlayerPrefs.GetInt ("LastStage") == 3) {
				enemyModel.ExpBonus = 40;
				enemyModel.GoldBonus = 40;
			}

			if (PlayerPrefs.GetInt ("LastStage") == 4) {
				enemyModel.ExpBonus = 70;
				enemyModel.GoldBonus = 70;
			}

			int currentStage = PlayerPrefs.GetInt ("CurrentStage");
			int lastStage = PlayerPrefs.GetInt ("LastStage");

			if (currentStage == lastStage) {
				PlayerPrefs.SetInt ("LastStage", PlayerPrefs.GetInt ("CurrentStage") + 1);
			}


			counter += 1;
			if (counter == 1) {
				saveExp (enemyModel.ExpBonus);
			}
			expBonus.text = "Você ganhou " + enemyModel.ExpBonus.ToString() + " de experiência!";
			goldBonus.text = "Você ganhou " + enemyModel.GoldBonus.ToString() + " de experiência!";
			rewardPanel.SetActive (true);
		}	
	}

	void saveExp(int _exp) {
		int playerExp = PlayerPrefs.GetInt("PlayerExp");
		playerExp += _exp;
		verifyLevel (playerExp);
		PlayerPrefs.SetInt ("PlayerExp", playerExp);
	}

	void verifyLevel (int _exp)
	{
		if (_exp < 5) {
			PlayerPrefs.SetInt ("PlayerLevel", 1);
		} else if (_exp >= 5 && _exp < 55) {
			PlayerPrefs.SetInt ("PlayerLevel", 2);
		} else if (_exp >= 55 &&_exp < 77) {
			PlayerPrefs.SetInt ("PlayerLevel", 3);
		} else if (_exp >= 77 &&_exp < 93) {
			PlayerPrefs.SetInt ("PlayerLevel", 4);
		} else if (_exp >= 93 &&_exp < 171) {
			PlayerPrefs.SetInt ("PlayerLevel", 5);
		} else if (_exp >= 171 &&_exp < 305) {
			PlayerPrefs.SetInt ("PlayerLevel", 6);
		} else if (_exp >= 305 &&_exp < 606) {
			PlayerPrefs.SetInt ("PlayerLevel", 7);
		} else if (_exp >= 606 &&_exp < 777) {
			PlayerPrefs.SetInt ("PlayerLevel", 8);
		} else if (_exp >= 777 &&_exp < 999) {
		PlayerPrefs.SetInt ("PlayerLevel", 9);
	}
	}
}
