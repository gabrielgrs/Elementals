using UnityEngine;
using System.Collections;


public class AttackTrigger : MonoBehaviour
{
    private GameObject player;
	private PlayerModel playerModel;
	private EnemyModel enemyModel;
	private GameObject enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerModel = player.gameObject.GetComponent<PlayerModel>();

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyModel = enemy.gameObject.GetComponent<EnemyModel>();
    }

    void OnTriggerEnter2D(Collider2D col)
    { 	
		print (enemyModel.Life);
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
			enemyModel.receiveDamage(playerModel.Attack);
			print (enemyModel.Life);
        }
    }
}