using UnityEngine;
using System.Collections;

public class GameStorage : MonoBehaviour {

	public PlayerModel playerModel;

	public GameStorage() { }

	public void saveGame() {
		PlayerPrefs.SetString("PlayerName", playerModel.Name);
		PlayerPrefs.SetInt("PlayerLevel", playerModel.Level);
		PlayerPrefs.SetInt("PlayerEXP", playerModel.Exp);
		PlayerPrefs.SetInt("PlayerGold", playerModel.Gold);
		// PlayerPrefs.SetInt("PlayerLastStage", playerModel.LastStage);
	}

	public void loadGame() {
		playerModel.Name = PlayerPrefs.GetString("PlayerName");
		playerModel.Level = PlayerPrefs.GetInt("PlayerLevel");
		playerModel.Exp = PlayerPrefs.GetInt("PlayerEXP");
		playerModel.Gold = PlayerPrefs.GetInt("PlayerGold");
		// playerModel.LastStage = PlayerPrefs.GetInt("PlayerLastStage");
	}


}