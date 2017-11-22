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
    private PlayerFactory playerFactory;
	private PlayerService playerService;

	public GameObject firstMagic;
	public GameObject secondMagic;
	public GameObject thirdMagic;


	private float lifeRecoveryCooldown;
	private float manaRecoveryCooldown;
	private float magicCooldown ;

    private MagicController magicController;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerModel = GetComponent<PlayerModel>();
		playerService = GetComponent<PlayerService> ();
		// playerModel = new PlayerModel ();
		// playerModel.Life = 10;
		// magic = GameObject.FindGameObjectWithTag ("Magic");
		magicController = firstMagic.GetComponent<MagicController> ();

		lifeRecoveryCooldown = 3f;
		manaRecoveryCooldown = 3f;
		magicCooldown = 0f;
     }

	void FixedUpdate()
	{
		playerService.verifyLevel (playerModel.Exp);
	}

    void Update()
    {
		// TIMERS
		magicCooldown -= Time.deltaTime;
		//! TIMERS

		Move();
        Attack();
        CastMagic();
        UsePotion();
		// recoveryStats ();
    }

    void Awake()
    {
        attackTrigger.enabled = false;
    }

	public void recoveryStats() {
		lifeRecoveryCooldown -= Time.deltaTime;
		manaRecoveryCooldown -= Time.deltaTime;
		if (lifeRecoveryCooldown < 0.1f) {
			playerModel.Life += 5;
			lifeRecoveryCooldown = 3f;
		}
		if (manaRecoveryCooldown < 0.1f) {
			playerModel.Mana += 5;
			manaRecoveryCooldown = 3f;
		}
	}

    public void Move()
    {
        // Move para a direita
        if (/*Input.GetAxisRaw("Horizontal") > 0 ||*/ Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Vector2.right * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            playerModel.FacingRight = true;
        }
        // Move para a esquerda
        if (/*Input.GetAxisRaw("Horizontal") < 0 || */Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(moveSpeed * Vector2.right * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
            playerModel.FacingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
			if (transform.position.y - GameObject.FindGameObjectWithTag ("Floor").transform.position.y < -3f) {
				rb2d.AddForce(transform.up * jumpForce);
			}
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown("f") && !attacking)
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
		if (Input.GetKeyDown(KeyCode.Alpha1) && magicCooldown < 0.1f && playerModel.Mana > 19)
        {
			Instantiate(firstMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +1.2f : -1.2f ), transform.position.y), transform.rotation);
			magicCooldown = 3f;
			playerModel.Mana -= 20;
        }
		if (Input.GetKeyDown(KeyCode.Alpha2) && magicCooldown < 0.1f && playerModel.Mana > 19 && playerModel.Level > 5) {
			Instantiate(secondMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +1.2f : -1.2f ), transform.position.y), transform.rotation);
			magicCooldown = 3f;
			playerModel.Mana -= 20;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && playerModel.Mana > 19 && playerModel.Level > 7) {
			// Barreira
			Instantiate(thirdMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +2f : -2f ), transform.position.y), transform.rotation);
			magicCooldown = 5f;
			playerModel.Mana -= 20;
		}
    }

    public void UsePotion()
    {
        if (Input.GetKeyDown(KeyCode.A) && playerModel.LifePotion > 0)
        {
            playerModel.Life += 10;
            playerModel.LifePotion -= 1;

            if (playerModel.Life > playerModel.MaxLife)
            {
                playerModel.Life = playerModel.MaxLife;
            }
            print("Poção de Mana utilizada!");
        }

        if (Input.GetKeyDown(KeyCode.S) && playerModel.ManaPotion > 0)
        {
            playerModel.Mana += 10;
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
	}

    public void receiveGold(int _gold)
    {
        print("Jogador recebeu gold: " + _gold);
        playerModel.Gold += _gold;
    }
}
