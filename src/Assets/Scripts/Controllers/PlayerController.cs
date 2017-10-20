﻿using System.Collections;
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

	public GameObject magic;
    private MagicController magicController;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerModel = GetComponent<PlayerModel>();
		// playerModel = new PlayerModel ();
		// playerModel.Life = 10;
		// magic = GameObject.FindGameObjectWithTag ("Magic");
		magicController = magic.GetComponent<MagicController> ();
  
     }


    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			// magicController.CastFirstMagic();
			Instantiate(magic, new Vector2(transform.position.x + (playerModel.FacingRight ? +1.2f : -1.2f ), transform.position.y), transform.rotation);
        }
    }


    public void receiveDamage(int damage)
    {
        print(playerModel.Life);
        int finalDamage = playerModel.Defense - damage;

        if (finalDamage < 1)
        {
            finalDamage = 1;
        }

        playerModel.Life -= finalDamage;
    }


}
