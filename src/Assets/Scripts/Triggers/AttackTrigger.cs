using UnityEngine;
using System.Collections;


public class AttackTrigger : MonoBehaviour
{
    private GameObject player;
	private PlayerModel playerModel;
	private GameObject enemy;
    private EnemyModel enemyModel;
    private EnemyController enemyController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerModel = player.gameObject.GetComponent<PlayerModel>();

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyModel = enemy.gameObject.GetComponent<EnemyModel>();
        enemyController = enemy.gameObject.GetComponent<EnemyController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    { 	
		if (col.isTrigger != true && col.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.F))
        {
			enemyController.ReceiveDamage(playerModel.Attack);
			print (enemyModel.Life);
        }
    }
}