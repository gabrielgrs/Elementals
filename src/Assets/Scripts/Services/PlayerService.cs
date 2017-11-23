using UnityEngine;

public class PlayerService : MonoBehaviour
{
    public GameObject Player;
    public PlayerModel PlayerModel;

	public PlayerService() { }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerModel = Player.GetComponent<PlayerModel>();

        PlayerModel.Name = "Batatão";

        PlayerModel.Died = false;
        PlayerModel.Gold = 0;
        PlayerModel.Exp = 30;

        PlayerModel.Life = 100; // PlayerModel.MaxLife;
        PlayerModel.Mana = 100; // PlayerModel.MaxMana;

        PlayerModel.LifePotion = 3;
        PlayerModel.ManaPotion = 3;

        PlayerModel.InFloor = true;
        PlayerModel.FacingRight = true;

        
    }

    void FixedUpdate()
    {
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
                PlayerModel.MaxLife = 0;
                PlayerModel.Life = 0;
                PlayerModel.MaxMana = 0;
                PlayerModel.Mana = 0;
                PlayerModel.Attack = 0;
                PlayerModel.Defense = 0;
                break;
            case 3:
                PlayerModel.MaxLife = 0;
                PlayerModel.Life = 0;
                PlayerModel.MaxMana = 0;
                PlayerModel.Mana = 0;
                PlayerModel.Attack = 0;
                PlayerModel.Defense = 0;
                break;
            case 4:
                PlayerModel.MaxLife = 0;
                PlayerModel.Life = 0;
                PlayerModel.MaxMana = 0;
                PlayerModel.Mana = 0;
                PlayerModel.Attack = 0;
                PlayerModel.Defense = 0;
                break;
            case 5:
                PlayerModel.MaxLife = 0;
                PlayerModel.Life = 0;
                PlayerModel.MaxMana = 0;
                PlayerModel.Mana = 0;
                PlayerModel.Attack = 0;
                PlayerModel.Defense = 0;
                break;
            case 6:
                PlayerModel.MaxLife = 0;
                PlayerModel.Life = 0;
                PlayerModel.MaxMana = 0;
                PlayerModel.Mana = 0;
                PlayerModel.Attack = 0;
                PlayerModel.Defense = 0;
                break;
            case 7:
                PlayerModel.MaxLife = 0;
                PlayerModel.Life = 0;
                PlayerModel.MaxMana = 0;
                PlayerModel.Mana = 0;
                PlayerModel.Attack = 0;
                PlayerModel.Defense = 0;
                break;
            case 8:
                PlayerModel.MaxLife = 0;
                PlayerModel.Life = 0;
                PlayerModel.MaxMana = 0;
                PlayerModel.Mana = 0;
                PlayerModel.Attack = 0;
                PlayerModel.Defense = 0;
                break;
            case 9:
                PlayerModel.MaxLife = 0;
                PlayerModel.Life = 0;
                PlayerModel.MaxMana = 0;
                PlayerModel.Mana = 0;
                PlayerModel.Attack = 0;
                PlayerModel.Defense = 0;
                break;
        }
    }
}