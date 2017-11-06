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


	void Start()
	{
		Magic = GameObject.FindGameObjectWithTag("EnemyAttackMagic");
		MagicModel = Magic.GetComponent<MagicModel>();

		player = GameObject.FindGameObjectWithTag ("Player");
		playerModel = player.GetComponent<PlayerModel> ();
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
			playerModel.Life -= 30;
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
	}


}
