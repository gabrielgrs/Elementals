using UnityEngine;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemy;
    public EnemyModel enemyModel;

	public IList<EnemyModel> enemyList;

    // Refazer esse método para ser dinâmico
    void Start()
    {
		enemyList = new List<EnemyModel> ();

		enemyList.Add (new EnemyModel { Attack = 100, Defense = 100, Mana = 100, MaxMana = 100, Died = false });
		enemyList.Add (new EnemyModel { Attack = 100, Defense = 100, Mana = 100, MaxMana = 100, Died = false });

        enemyModel.MaxLife = 100;
        enemyModel.Life = 100;
        
        enemyModel.MaxMana = 100;
        enemyModel.Mana = 100;

        enemyModel.Attack = 10;
        enemyModel.Defense = 10;
        enemyModel.Died = false;
    }
}