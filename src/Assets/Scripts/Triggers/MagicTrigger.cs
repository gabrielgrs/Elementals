using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrigger : MonoBehaviour
{

    public float MagicSpeed = 5f;

    private GameObject Magic;
    private MagicModel MagicModel;

    private GameObject Enemy;
    private EnemyController EnemyController;
	private EnemyModel EnemyModel;

	private GameObject PlayerMagicDefense;

    void Start()
    {
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		EnemyController = Enemy.GetComponent<EnemyController>();
		// EnemyController = new EnemyController ();
		EnemyModel = Enemy.GetComponent<EnemyModel> ();

        Magic = GameObject.FindGameObjectWithTag("PlayerAttackMagic");
        MagicModel = Magic.GetComponent<MagicModel>();
	
    }

    void Update()
    {
        transform.Translate(new Vector2(MagicSpeed * Time.deltaTime, 0));

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.CompareTag("Enemy"))
		{
			print ("Magica acertou inimigo!!");
			EnemyController.ReceiveDamage (20);
			Destroy (Magic);
		}
			
		if (collider.CompareTag ("EnemyDefenseMagic")) {
			
			print ("Acertou a barreira magica!");
			Destroy (Magic);
		}

		if (collider.CompareTag ("EnemyAttackMagic")) {
			Destroy (Magic);
		}
    }




}
