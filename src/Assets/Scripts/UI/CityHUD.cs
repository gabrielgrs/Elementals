using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityHUD : MonoBehaviour {


	public GameStorage gameStorage;

	public GameObject playerStatsPanel;
	public Image elementPanel;
	public Text playerName;
	public Text playerLevel;
	public Text playerGold;
	public Slider playerExp;

	void Start() {
		gameStorage = gameObject.AddComponent<GameStorage> ();
		gameStorage.loadGame ();
	}

	void FixedUpdate () {
		playerStatsPanel.transform.position = new Vector2(Screen.width / 10, Screen.height - 50);
		playerName.text = gameStorage.getPlayerName ();
		playerLevel.text = gameStorage.getPlayerLevel ().ToString();
		playerGold.text = gameStorage.getPlayerGold ().ToString();
		elementPanel.color = validateElementColor(gameStorage.getPlayerElement());

    }

	private Color validateElementColor(string _element) {
        if (_element == "Vento")
            return Color.green;
        if (_element == "Água")
            return Color.blue;
        if (_element == "Fogo")
            return Color.red;
        if (_element == "Terra")
            return Color.magenta;
        else
            return Color.cyan;

    }
}
