using UnityEngine;
using System.Collections;


public class AttackTrigger : MonoBehaviour
{
    public GameObject player;
    public PlayerModel playerModel;
    public EnemyModel enemyModel;
    public GameObject enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerModel = player.gameObject.GetComponent<PlayerModel>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyModel = enemy.gameObject.GetComponent<EnemyModel>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
			enemyModel.receiveDamage(playerModel.Attack);
        }

    }
}