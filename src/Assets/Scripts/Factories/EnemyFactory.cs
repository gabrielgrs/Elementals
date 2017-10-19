using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemy;
    public EnemyModel enemyModel;

    // Refazer esse método para ser dinâmico
    public EnemyModel generateEnemy()
    {
        enemyModel = new EnemyModel();

        enemyModel.MaxLife = 100;
        enemyModel.Life = 100;
        
        enemyModel.MaxMana = 100;
        enemyModel.Mana = 100;

        enemyModel.Attack = 10;
        enemyModel.Defense = 10;
        enemyModel.Died = false;


        return enemyModel;
    }
}