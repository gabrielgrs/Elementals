using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float moveSpeed = 5f;
    private float jumpForce = 300f;

    private Rigidbody2D rb2d;
    public Transform floorCheker;

    public bool attacking = false;
    public float attackTimer = 0;
    public float attackCoolDown = 0.3f;

    public Collider2D attackTrigger;

    private PlayerModel playerModel;
    private PlayerFactory playerFactory;

	public GameObject firstMagic;
	public GameObject secondMagic;
	public GameObject thirdMagic;

	private float magicCooldown ;

    private MagicController magicController;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerModel = GetComponent<PlayerModel>();
		// playerModel = new PlayerModel ();
		// playerModel.Life = 10;
		// magic = GameObject.FindGameObjectWithTag ("Magic");
		magicController = firstMagic.GetComponent<MagicController> ();


		magicCooldown = 0f;
     }


    void Update()
    {
		// TIMERS
		magicCooldown -= Time.deltaTime;
		//! TIMERS

		Move();
        Attack();
        CastMagic();
    }

    void Awake()
    {
        attackTrigger.enabled = false;
    }

    public void Move()
    {
        // Move para a direita
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(moveSpeed * Vector2.right * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            playerModel.FacingRight = true;
        }
        // Move para a esquerda
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(moveSpeed * Vector2.right * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
            playerModel.FacingRight = false;
        }

        if (playerModel.InFloor && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(transform.up * jumpForce);
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
		if (Input.GetKeyDown(KeyCode.Alpha1) && magicCooldown < 0.1f)
        {
			Instantiate(firstMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +1.2f : -1.2f ), transform.position.y), transform.rotation);
			magicCooldown = 3f;
        }
		if (Input.GetKeyDown(KeyCode.Alpha2) && magicCooldown < 0.1f) {
			Instantiate(secondMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +1.2f : -1.2f ), transform.position.y), transform.rotation);
			magicCooldown = 3f;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			// Barreira
			Instantiate(thirdMagic, new Vector2(transform.position.x + (playerModel.FacingRight ? +2f : -2f ), transform.position.y), transform.rotation);
			magicCooldown = 5f;
		}
    }


    public void receiveDamage(int damage)
    {
        int finalDamage = playerModel.Defense - damage;

        if (finalDamage < 1)
        {
            finalDamage = 1;
        }

        playerModel.Life -= finalDamage;
    }


}
