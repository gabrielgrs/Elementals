using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityHUD : MonoBehaviour {


	public GameStorage gameStorage;
	public Text playerName;
	public Text playerLevel;
	public Text playerGold;
	public Slider playerExp;

	void Awake() {
		gameStorage = gameObject.AddComponent<GameStorage> ();
		gameStorage.loadGame ();
	}

	void FixedUpdate () {
		playerName.text = gameStorage.getPlayerName ();
		playerLevel.text = gameStorage.getPlayerLevel ().ToString();
		playerGold.text = gameStorage.getPlayerGold ().ToString();
	}
}
