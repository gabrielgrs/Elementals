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

    public EnemyModel enemyModel;
	public EnemyService enemyService;

    public PlayerController playerController;
    public PlayerModel playerModel;

	private float magicCooldown;

	// TEMP 
	public bool direction;
	public float directionTime;
	private float timeInDirection;

	public GameObject firstMagic;
	public GameObject secondMagic;



    // Use this for initialization
    void Awake()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		playerModel = player.gameObject.GetComponent<PlayerModel>();
		playerController = player.GetComponent<PlayerController>();

		enemy = GameObject.FindGameObjectWithTag("Enemy");
		enemyService = enemy.gameObject.GetComponent<EnemyService> ();
		enemyModel = enemy.gameObject.GetComponent<EnemyModel> ();
		print (enemyModel.name);

		target = player.transform;

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
		if (AttackTime < 1f) {
			playerController.receiveDamage (enemyModel.Attack);
			AttackTime = 3f;
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
		int finalDamage = damage - enemyModel.Defense;

        if (finalDamage < 1)
        {
            finalDamage = 1;
        }

        enemyModel.Life -= finalDamage;

		if (enemyModel.Life < 1) {
			Destroy(enemy);
		}
    }
		
}