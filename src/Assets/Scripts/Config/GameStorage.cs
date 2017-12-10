using UnityEngine;
using System.Collections;

public class GameStorage : MonoBehaviour {

	public GameObject player;
	public PlayerModel playerModel;

    void Start() {
        
        // Light gambiarra lol
        if (PlayerPrefs.GetString("PlayerName") != "") {
            playerModel = loadPlayer();
        }
    }

	public void saveGame() {

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

    public PlayerModel loadPlayer() {
        playerModel = gameObject.AddComponent<PlayerModel>();
        
        playerModel.Name = getPlayerName();
        playerModel.Level = getPlayerLevel();
        playerModel.Exp = getPlayerExp();
        playerModel.Gold = getPlayerGold();
        playerModel.Element = getPlayerElement();
        playerModel.LifePotion = getPlayerLifePotion();
        playerModel.ManaPotion = getPlayerManaPotion();

        return playerModel;
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

    public void setLifePotion(int _lifePotion) {
        PlayerPrefs.SetInt("PlayerLifePotion", _lifePotion);
    }

    public void setManaPotion(int _manaPotion) {
        PlayerPrefs.SetInt("PlayerManaPotion", _manaPotion);
    }

    public void setPlayerElement(string _playerElement)
    {
        PlayerPrefs.SetString("PlayerElement", _playerElement);
    }

    public void setLastStage(int _playerLastStage) {
        PlayerPrefs.SetInt("PlayerLastStage", _playerLastStage);
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

    public int getPlayerLifePotion() {
        return PlayerPrefs.GetInt("PlayerLifePotion");
    }

    public int getPlayerManaPotion() {
        return PlayerPrefs.GetInt("PlayerManaPotion");
    }

    public int getLastStage() {
        return PlayerPrefs.GetInt("PlayerLastStage");
    }



    // CurrentBattle : verifica qual batalha o personagem está atualmente
    public int getCurrentBattle() {
        return PlayerPrefs.GetInt("PlayerCurrentbattle");
    }

    public void setCurrentBattle(int _currentBattle) {
        PlayerPrefs.SetInt("PlayerCurrentbattle", _currentBattle);
    }

}