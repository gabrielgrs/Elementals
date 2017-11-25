using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public GameObject enemy;
    public EnemyModel enemyModel;


    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyModel = enemy.GetComponent<EnemyModel>();        
    }

	public void generateFirstEnemy()
    {
        enemyModel.name = "Gandalf";
		enemyModel.Life = enemyModel.MaxLife = 100;
		enemyModel.Mana = enemyModel.MaxMana = 100;
		enemyModel.Attack = 10;
		enemyModel.Defense = 10;
    }

    public void generateSecondEnemy()
    {

    }

    public void generateThirdEnemy()
    {

    }

    public void generateFourtEnemy()
    {

    }


}