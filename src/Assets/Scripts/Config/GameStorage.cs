using UnityEngine;
using System.Collections;

public class GameStorage : MonoBehaviour {

	public GameObject player;
	public PlayerModel playerModel;



	public void saveGame() {
		PlayerPrefs.SetString("PlayerName", playerModel.Name);

        PlayerPrefs.SetString("PlayerElement", playerModel.Element);

        PlayerPrefs.SetInt("PlayerLevel", playerModel.Level);
		PlayerPrefs.SetInt("PlayerEXP", playerModel.Exp);
		PlayerPrefs.SetInt("PlayerGold", playerModel.Gold);

		PlayerPrefs.SetInt("LifePotion", playerModel.LifePotion);
		PlayerPrefs.SetInt("ManaPotion", playerModel.ManaPotion);

		PlayerPrefs.SetInt("LastStage", playerModel.LastStage);
  

		print ("SaveGame chamado!");
	}

	public void loadGame() {
		playerModel.Name = PlayerPrefs.GetString("PlayerName");
		playerModel.Level = PlayerPrefs.GetInt("PlayerLevel");
		playerModel.Exp = PlayerPrefs.GetInt("PlayerEXP");
		playerModel.Gold = PlayerPrefs.GetInt("PlayerGold");

		playerModel.LifePotion = PlayerPrefs.GetInt ("LifePotion");
		playerModel.ManaPotion = PlayerPrefs.GetInt ("ManaPotion");
		playerModel.LastStage = PlayerPrefs.GetInt("LastStage");

		playerModel.Element = PlayerPrefs.GetString("PlayerElement");

		print ("LoadGame chamado!");
	}

    public void resetGame()
    {
        PlayerPrefs.DeleteAll();
    }

    // Setters
    public void setPlayerName(string _playerName)
    {
        PlayerPrefs.SetString("PlayerName", _playerName);
    }

    public void setPlayerLevel(int _playerLevel)
    {
        PlayerPrefs.SetInt("PlayerLevel", _playerLevel);
    }

    public void setPlayerGold(int _playerGold)
    {
        PlayerPrefs.SetInt("PlayerGold", _playerGold);
    }

    public void setPlayerExp(int _playerExp)
    {
        PlayerPrefs.SetInt("PlayerExp", _playerExp);
    }

    public void setPlayerElement(string _playerElement)
    {
        PlayerPrefs.SetString("PlayerElement", _playerElement);
    }

    // Getters
    public string getPlayerName() {
		return PlayerPrefs.GetString ("PlayerName");
	}

	public int getPlayerLevel() {
		return PlayerPrefs.GetInt ("PlayerLevel");
	}

	public int getPlayerGold() {
		return PlayerPrefs.GetInt ("PlayerGold");
	}

	public int getPlayerExp() {
		return PlayerPrefs.GetInt ("PlayerExp");
	}

    public string getPlayerElement()
    {
        return PlayerPrefs.GetString("PlayerElement");
    }


}