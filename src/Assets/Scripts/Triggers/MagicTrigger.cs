using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrigger : MonoBehaviour
{

    public float magicSpeed = 5f;

	private GameObject magic;
	private MagicModel magicModel;

	private GameObject enemy;
	private EnemyController enemyController;
	private EnemyModel enemyModel;

	private GameObject playerMagicDefense;

    void Start()
    {
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		enemyController = enemy.GetComponent<EnemyController>();
		// EnemyController = new EnemyController ();
		enemyModel = enemy.GetComponent<EnemyModel> ();

        magic = GameObject.FindGameObjectWithTag("PlayerAttackMagic");
        magicModel = magic.GetComponent<MagicModel>();
    }

    void Update()
    {
        transform.Translate(new Vector2(magicSpeed * Time.deltaTime, 0));
    }

	void FixedUpdate()
	{
		if (Vector2.Distance(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 15) {
			Destroy(GameObject.FindGameObjectWithTag("PlayerAttackMagic"));
		}
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.CompareTag("Enemy"))
		{
			print ("Magica acertou inimigo!!");
			enemyController.ReceiveDamage (20);
			Destroy (magic);
		}
			
		if (collider.CompareTag ("EnemyDefenseMagic")) {
			
			print ("Acertou a barreira magica!");
			Destroy (magic);
		}

		if (collider.CompareTag ("EnemyAttackMagic")) {
			Destroy (magic);
		}
    }




}
