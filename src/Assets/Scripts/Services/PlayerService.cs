using UnityEngine;

public class PlayerService : MonoBehaviour
{
    public GameObject player;
    public PlayerModel playerModel;

    void Start() {   }

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		playerModel = player.GetComponent<PlayerModel>();

		playerModel.Name = PlayerPrefs.GetString("Name") != "" ? PlayerPrefs.GetString("Name") : "Sem Nome!";

		playerModel.Died = false;
		playerModel.Gold = PlayerPrefs.GetInt("PlayerGold");
		playerModel.Exp = PlayerPrefs.GetInt("PlayerExp") + 300;

		playerModel.Life = playerModel.MaxLife = 100;
		playerModel.Mana = playerModel.MaxMana = 100;

		playerModel.LifePotion = 3;
		playerModel.ManaPotion = 3;

		playerModel.InFloor = true;
		playerModel.FacingRight = true;

		playerModel.Level = verifyLevel(playerModel.Exp);
		VerifyStats(playerModel.Level);
	}

    public int verifyLevel(int _exp)
    {
        if (_exp < 5) return 1;
        if (_exp < 11) return 2;
        if (_exp < 15) return 3;
        if (_exp < 27) return 4;
        if (_exp < 43) return 5;
        if (_exp < 71) return 6;
        if (_exp < 115) return 7;
        if (_exp < 186) return 8;
        if (_exp < 301) return 9;

        else return -1;
    }

	public void VerifyStats(int _level)
    {
        switch (_level)
        {
            case 1:
                playerModel.MaxLife = 100;
                playerModel.MaxMana = 100;
                playerModel.Attack = 10;
                playerModel.Defense = 10;
                break;
            case 2:
                playerModel.MaxLife = 120;
                playerModel.Life = 120;
                playerModel.MaxMana = 120;
                playerModel.Mana = 120;
                playerModel.Attack = 12;
                playerModel.Defense = 12;
                break;
            case 3:
                playerModel.MaxLife = 150;
                playerModel.Life = 150;
                playerModel.MaxMana = 150;
                playerModel.Mana = 150;
                playerModel.Attack = 15;
                playerModel.Defense = 15;
                break;
            case 4:
                playerModel.MaxLife = 200;
                playerModel.Life = 200;
                playerModel.MaxMana = 200;
                playerModel.Mana = 200;
                playerModel.Attack = 20;
                playerModel.Defense = 20;
                break;
            case 5:
                playerModel.MaxLife = 250;
                playerModel.Life = 250;
                playerModel.MaxMana = 250;
                playerModel.Mana = 250;
                playerModel.Attack = 25;
                playerModel.Defense = 25;
                break;
            case 6:
                playerModel.MaxLife = 300;
                playerModel.Life = 300;
                playerModel.MaxMana = 300;
                playerModel.Mana = 300;
                playerModel.Attack = 30;
                playerModel.Defense = 30;
                break;
            case 7:
                playerModel.MaxLife = 350;
                playerModel.Life = 350;
                playerModel.MaxMana = 350;
                playerModel.Mana = 350;
                playerModel.Attack = 35;
                playerModel.Defense = 35;
                break;
            case 8:
                playerModel.MaxLife = 400;
                playerModel.Life = 400;
                playerModel.MaxMana = 400;
                playerModel.Mana = 400;
                playerModel.Attack = 40;
                playerModel.Defense = 40;
                break;
            case 9:
                playerModel.MaxLife = 450;
                playerModel.Life = 450;
                playerModel.MaxMana = 450;
                playerModel.Mana = 450;
                playerModel.Attack = 45;
                playerModel.Defense = 45;
                break;
			default: 
				playerModel.Name = "Default";
				break;
        }
    }
}