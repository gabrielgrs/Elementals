using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float moveSpeed = 5f;
    private float jumpForce = 500f;

    private Rigidbody2D rb2d;
    public Transform floorCheker;

    public bool attacking = false;
    public float attackTimer = 0;
    public float attackCoolDown = 0.3f;

    public Collider2D attackTrigger;

    private PlayerModel playerModel;
	private PlayerService playerService;

	public GameObject firstMagic;
	public GameObject secondMagic;
	public GameObject thirdMagic;

	private float magicCooldown ;

    private MagicController magicController;

    private GameStorage gameStorage;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerModel = GetComponent<PlayerModel>();
		playerService = GetComponent<PlayerService> ();


		magicController = firstMagic.GetComponent<MagicController> ();

        gameStorage = gameObject.AddComponent<GameStorage>();

		magicCooldown = 0f;


        bool test = true;
        if (test)
        {
            playerService.createPlayer();
        }
    }

    void Update()
    {
		magicCooldown -= Time.deltaTime;

		Move();
        Attack();
        CastMagic();
        UsePotion();
    }

	void FixedUpdate() {
		print (magicCooldown);
	}

    void Awake()
    {
        attackTrigger.enabled = false;
    }
		

    public void Move()
    {
        // Move para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Vector2.right * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            playerModel.FacingRight = true;
        }
        // Move para a esquerda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(moveSpeed * Vector2.right * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
            playerModel.FacingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
			float distanceToFloor = transform.position.y - GameObject.FindGameObjectWithTag ("Floor").transform.position.y;
			print(distanceToFloor);
			print (distanceToFloor > -3f && distanceToFloor > -1f);
			if (distanceToFloor > -3f && distanceToFloor < -2f) {
				rb2d.AddForce(transform.up * jumpForce);
			}
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown("z") && !attacking)
        {
            print("Ataquei!");

            attacking = true;
            attackTimer = attackCoolDown;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime / 2;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }

    public void CastMagic()
    {
		if (Input.GetKeyDown(KeyCode.X) && magicCooldown < 0.1f && playerModel.Mana > 19)
        {
			Instantiate(firstMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +1.2f : -1.2f ), transform.position.y), transform.rotation);
			magicCooldown = 3f;
			playerModel.Mana -= 20;
        }
		if (Input.GetKeyDown(KeyCode.C) && magicCooldown < 0.1f && playerModel.Mana > 19 && playerModel.Level > 50) {
			Instantiate(secondMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +1.2f : -1.2f ), transform.position.y), transform.rotation);
			magicCooldown = 3f;
			playerModel.Mana -= 20;
		}
		if (Input.GetKeyDown (KeyCode.V) && magicCooldown < 0.1f && playerModel.Mana > 19) {
			// Barreira
			Instantiate(thirdMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +2f : -2f ), transform.position.y), transform.rotation);
			magicCooldown = 5f;
			playerModel.Mana -= 20;
		}
    }

    public void UsePotion()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerModel.LifePotion > 0)
        {
            playerModel.Life += 20;
            playerModel.LifePotion -= 1;

            if (playerModel.Life > playerModel.MaxLife)
            {
                playerModel.Life = playerModel.MaxLife;
            }
            print("Poção de Mana utilizada!");
        }

        if (Input.GetKeyDown(KeyCode.G) && playerModel.ManaPotion > 0)
        {
            playerModel.Mana += 20;
            playerModel.ManaPotion -= 1;

            if (playerModel.Mana > playerModel.MaxMana)
            {
                playerModel.Mana = playerModel.MaxMana;
            }
            print("Poção de Vida utilizada!");
        }
    }

    public void receiveDamage(int damage)
    {
		int finalDamage = damage - playerModel.Defense;

        if (finalDamage < 1)
        {
            finalDamage = 1;
        }

        playerModel.Life -= finalDamage;

		if (playerModel.Life < 1) {
			Destroy (GameObject.FindGameObjectWithTag("Player"));
		}
    }

	public void receiveExp(int _exp) {
		print ("Jogador recebeu experiencia: " + _exp);
		playerModel.Exp += _exp;
        gameStorage.setPlayerExp(_exp);
	}

    public void receiveGold(int _gold)
    {
        print("Jogador recebeu gold: " + _gold);
        playerModel.Gold += _gold;
        gameStorage.setPlayerGold(_gold);
    }

	public void validateLevel(int _stageLevel) {
		if (_stageLevel > playerModel.LastStage) {
			playerModel.LastStage = _stageLevel;
		}
	}
}
