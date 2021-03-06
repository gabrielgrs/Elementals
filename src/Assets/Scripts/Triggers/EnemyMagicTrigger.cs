﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagicTrigger : MonoBehaviour
{

	public float MagicSpeed = 5f;

	private GameObject Magic;
	private MagicModel MagicModel;

	public GameObject GameOver;

	public GameObject player;
	public PlayerModel playerModel;
	public PlayerController playerController;

	public GameObject enemy;
	public EnemyModel enemyModel;


	void Awake()
	{
		Magic = GameObject.FindGameObjectWithTag("EnemyAttackMagic");
		MagicModel = Magic.GetComponent<MagicModel>();

		player = GameObject.FindGameObjectWithTag ("Player");
		playerModel = player.GetComponent<PlayerModel> ();
		playerController = player.GetComponent<PlayerController> ();

		//enemy = GameObject.FindGameObjectWithTag ("Enemy");
		//enemyModel = enemy.gameObject.GetComponent<EnemyModel> ();

	}

	void FixedUpdate()
	{
		if (Vector2.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position) > 15) {
			Destroy(GameObject.FindGameObjectWithTag("EnemyAttackMagic"));
		}
	}

	void Update()
	{
		transform.Translate(new Vector2(MagicSpeed * Time.deltaTime, 0));
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("PlayerBody"))
		{
			print ("Magica acertou jogador!!");
			playerController.receiveDamage (30, PlayerPrefs.GetString("EnemyElement"));
			Destroy (Magic);
		}

		if (collider.CompareTag ("PlayerDefenseMagic")) {
			print ("Acertou a barreira magica!");
			Destroy (Magic);
			Destroy (GameObject.FindGameObjectWithTag ("PlayerDefenseMagic"));
		}

		if (collider.CompareTag ("PlayerAttackMagic")) {
			Destroy (Magic);
		}

		if (collider.CompareTag ("Limit")) {
			Destroy (Magic);
		}
	}


}
