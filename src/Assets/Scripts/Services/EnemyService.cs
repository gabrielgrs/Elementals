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