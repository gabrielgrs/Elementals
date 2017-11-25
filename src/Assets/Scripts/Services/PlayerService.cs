using UnityEngine;

public class PlayerService : MonoBehaviour
{
    public GameObject Player;
    public PlayerModel PlayerModel;

	public PlayerService() { }

    void Start() {   }

	void Awake() {
		Player = GameObject.FindGameObjectWithTag("Player");
		PlayerModel = Player.GetComponent<PlayerModel>();

		PlayerModel.Name = PlayerPrefs.GetString("Name") != "" ? PlayerPrefs.GetString("Name") : "Sem Nome!";

		PlayerModel.Died = false;
		PlayerModel.Gold = PlayerPrefs.GetInt("PlayerGold");
		PlayerModel.Exp = PlayerPrefs.GetInt("PlayerExp");

		PlayerModel.Life = PlayerModel.MaxLife = 100;
		PlayerModel.Mana = PlayerModel.MaxMana = 100;

		PlayerModel.LifePotion = 3;
		PlayerModel.ManaPotion = 3;

		PlayerModel.InFloor = true;
		PlayerModel.FacingRight = true; 

		PlayerModel.Level = verifyLevel(PlayerModel.Exp);
		VerifyStats(PlayerModel.Level);
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
                PlayerModel.MaxLife = 100;
                PlayerModel.MaxMana = 100;
                PlayerModel.Attack = 10;
                PlayerModel.Defense = 10;
                break;
            case 2:
                PlayerModel.MaxLife = 120;
                PlayerModel.Life = 120;
                PlayerModel.MaxMana = 120;
                PlayerModel.Mana = 120;
                PlayerModel.Attack = 12;
                PlayerModel.Defense = 12;
                break;
            case 3:
                PlayerModel.MaxLife = 150;
                PlayerModel.Life = 150;
                PlayerModel.MaxMana = 150;
                PlayerModel.Mana = 150;
                PlayerModel.Attack = 15;
                PlayerModel.Defense = 15;
                break;
            case 4:
                PlayerModel.MaxLife = 200;
                PlayerModel.Life = 200;
                PlayerModel.MaxMana = 200;
                PlayerModel.Mana = 200;
                PlayerModel.Attack = 20;
                PlayerModel.Defense = 20;
                break;
            case 5:
                PlayerModel.MaxLife = 250;
                PlayerModel.Life = 250;
                PlayerModel.MaxMana = 250;
                PlayerModel.Mana = 250;
                PlayerModel.Attack = 25;
                PlayerModel.Defense = 25;
                break;
            case 6:
                PlayerModel.MaxLife = 300;
                PlayerModel.Life = 300;
                PlayerModel.MaxMana = 300;
                PlayerModel.Mana = 300;
                PlayerModel.Attack = 30;
                PlayerModel.Defense = 30;
                break;
            case 7:
                PlayerModel.MaxLife = 350;
                PlayerModel.Life = 350;
                PlayerModel.MaxMana = 350;
                PlayerModel.Mana = 350;
                PlayerModel.Attack = 35;
                PlayerModel.Defense = 35;
                break;
            case 8:
                PlayerModel.MaxLife = 400;
                PlayerModel.Life = 400;
                PlayerModel.MaxMana = 400;
                PlayerModel.Mana = 400;
                PlayerModel.Attack = 40;
                PlayerModel.Defense = 40;
                break;
            case 9:
                PlayerModel.MaxLife = 450;
                PlayerModel.Life = 450;
                PlayerModel.MaxMana = 450;
                PlayerModel.Mana = 450;
                PlayerModel.Attack = 45;
                PlayerModel.Defense = 45;
                break;
			default: 
				PlayerModel.Name = "Default";
				break;
        }
    }
}