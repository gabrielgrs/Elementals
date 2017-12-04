using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public string Name;

    public int MaxLife;
    public int Life;

    public int MaxMana;
    public int Mana;

	public int ExpBonus;
    public int GoldBonus;

	public int EnemyStage;

    public int Attack;
    public int Defense;
    public bool Died;

    public string FirstSkill;
    public string SecondSkill;
    public string ThirdSkill;


    void Start()
    {
        Name = "Cebolinha";

        MaxLife = 30;
        Life = 30;

        MaxMana = 30;
        Mana = 30;

        Attack = 3;
        Defense = 3;
        Died = false;

		ExpBonus = 10;
        GoldBonus = 10;

		EnemyStage = 1;
    }
}
