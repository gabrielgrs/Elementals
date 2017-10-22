using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagicTrigger : MonoBehaviour
{

	public float MagicSpeed = 5f;

	private GameObject Magic;
	private MagicModel MagicModel;

	public GameObject GameOver;


	void Start()
	{
		Magic = GameObject.FindGameObjectWithTag("EnemyAttackMagic");
		MagicModel = Magic.GetComponent<MagicModel>();
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
			Destroy (Magic);

		}

		if (collider.CompareTag ("PlayerDefenseMagic")) {
			print ("Acertou a barreira magica!");
			Destroy (Magic);
			Destroy (GameObject.FindGameObjectWithTag ("PlayerDefenseMagic"));
		}
	}


}
