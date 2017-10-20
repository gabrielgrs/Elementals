using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public GameObject player;
    public PlayerModel playerModel;
    public PlayerService playerService;

    // Refazer esse método para ser dinâmico
    void Start()
    {
        playerModel.Name = "";
        playerModel.Exp = 0;
        playerModel.Level = playerService.verifyLevel(playerModel.Exp);
        playerModel.Gold = 0;

        playerModel.MaxLife = 100;
        playerModel.Life = 100;

        playerModel.MaxMana = 100;
        playerModel.Mana = 100;

        playerModel.Attack = 10;
        playerModel.Defense = 10;
        playerModel.Died = false;
        playerModel.FirstSkill = null;
        playerModel.SecondSkill = null;
        playerModel.ThirdSkill = null;
    }
}