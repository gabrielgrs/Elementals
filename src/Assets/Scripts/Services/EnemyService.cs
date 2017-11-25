using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public GameObject Enemy;
    public EnemyModel EnemyModel;


    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyModel = Enemy.GetComponent<EnemyModel>();        
    }

    public void generateFirstEnemy()
    {
        EnemyModel.name = "Gandalf";
		EnemyModel.Life = EnemyModel.MaxLife = 100;
		EnemyModel.Mana = EnemyModel.MaxMana = 100;
		EnemyModel.Attack = 10;
		EnemyModel.Defense = 10;
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