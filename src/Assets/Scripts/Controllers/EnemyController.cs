using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public Transform target;
    public GameObject enemy;
    public GameObject player;
    private float range;
    public float speed;
	public bool rightDirection;

    public float AttackTime;
    public float coolDown;


    public EnemyFactory enemyFactory;
    public EnemyModel enemyModel;

    public PlayerController playerController;
    public PlayerModel playerModel;
    public PlayerFactory playerFactory;

	private float magicCooldown;

	// TEMP 
	public bool direction;
	public float directionTime;
	private float timeInDirection;

	public GameObject firstMagic;
	public GameObject secondMagic;



    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;

        enemyModel = enemy.GetComponent<EnemyModel>();
        playerModel = player.gameObject.GetComponent<PlayerModel>();
        playerController = player.GetComponent<PlayerController>();

        range = 10f;
        speed = 2f;
        AttackTime = 2f;
        coolDown = 2f;
		magicCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
		magicCooldown -= Time.deltaTime;
		AttackTime -= Time.deltaTime;
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
			rotateEnemy ();
			CastMagic ();
			transform.Translate(new Vector2(speed * Time.deltaTime, 0));
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
		if (direction) {
			transform.eulerAngles = new Vector2(0, 0);
		} else {
			transform.eulerAngles = new Vector2(0, 180);
		}
		transform.Translate(Vector2.right * speed * Time.deltaTime);

		timeInDirection += Time.deltaTime;
		if (timeInDirection >= directionTime) {
			timeInDirection = 0;
			directionTime = Random.Range (2, 5);
			direction = !direction;
		}
    }

	void rotateEnemy() {
		if (Vector2.Distance(enemy.transform.position, player.transform.position) >2f ) {
			if (transform.position.x < player.transform.position.x) {
				rightDirection = true;
			} else {
				rightDirection = false;
			}
			if (rightDirection) {
				transform.eulerAngles = new Vector2 (0, 0);
			} else {
				transform.eulerAngles = new Vector2 (0, 180);
			}
		}
	}

	public void AttackCooldown() {
        // AttackTime
        if (AttackTime < 0.1f)
        {
			// AttackTime = 5f;
            Attack();

        }
	}

	public void CastMagic()
	{
		if (magicCooldown < 0.1f)
		{	
			
			//Instantiate(secondMagic, new Vector2(transform.position.x + (rightDirection ? +2f : -2f ), transform.position.y), transform.rotation);
			//magicCooldown = 5f;
			Instantiate(firstMagic, new Vector2(transform.position.x + (rightDirection ? +2f : -2f ), transform.position.y), transform.rotation);
			magicCooldown = 5f;
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

        enemyModel.Life -= finalDamage;

		if (enemyModel.Life < 1) {
			Destroy(GameObject.FindGameObjectWithTag("Enemy"));
		}
    }
}