using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public Transform target;
    public GameObject enemy;
    public GameObject player;
    public float range;
    public float speed;

    public float AttackTime;
    public float coolDown;


    public EnemyFactory enemyFactory;
    public EnemyModel enemyModel;

    public PlayerController playerController;
    public PlayerModel playerModel;
    public PlayerFactory playerFactory;



    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        enemyModel = enemy.GetComponent<EnemyModel>();
        playerModel = player.gameObject.GetComponent<PlayerModel>();
        playerController = player.GetComponent<PlayerController>();



        range = 10f;
        speed = 0;
        AttackTime = 0.5f;
        coolDown = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Attack()
    {
        playerController.receiveDamage (enemyModel.Attack);
    }

    public void Move()
    {
        range = Vector2.Distance(enemy.transform.position, player.transform.position);
        if (range < 15f)
        {
            transform.Translate(Vector2.MoveTowards(enemy.transform.position, player.transform.position, range) * speed * Time.deltaTime);
            if (range < 3f)
            {
				AttackCooldown();
            }
        }
        else
        {
            Patrol();
        }
    }

    public void Patrol()
    {
		
    }

	public void AttackCooldown() {
                // AttackTime
                if (AttackTime > 0)
                {
                    AttackTime -= Time.deltaTime / 2;
                }
                if (AttackTime < 0)
                {
                    AttackTime = 0;
                }
                if (AttackTime == 0)
                {
                    Attack();
                }
	}

    public void ReceiveDamage(int damage)
    {
        print(enemyModel.Life);
        int finalDamage = enemyModel.Defense - damage;

        if (finalDamage < 1)
        {
            finalDamage = 1;
        }

        playerModel.Life -= finalDamage;
    }
}