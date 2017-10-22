﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public string Name;

    public int MaxLife;
    public int Life;

    public int MaxMana;
    public int Mana;

    public int Attack;
    public int Defense;
    public bool Died;

    public string FirstSkill;
    public string SecondSkill;
    public string ThirdSkill;

    void Start()
    {
        Name = "Cebolinha";

        MaxLife = 100;
        Life = 100;

        MaxMana = 100;
        Mana = 100;

        Attack = 10;
        Defense = 10;
        Died = false;
    }

    public void receiveDamage(int damage)
    {
        print(this.Life);
        int finalDamage = damage - this.Defense;
        if (finalDamage < 0)
        {
            finalDamage = 1;
        }
        this.Life -= finalDamage;
    }

    public void verifyLife()
    {
        if (Life < 1)
        {
            Died = true;
            print("Inimigo Morto");
        }
    }

}