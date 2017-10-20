using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrigger : MonoBehaviour
{

    private float MagicSpeed = 5f;

    private GameObject Magic;
    private MagicModel MagicModel;

    private GameObject Enemy;
    private EnemyController EnemyController;

    void Start()
    {
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		EnemyController = Enemy.GetComponent<EnemyController>();

        Magic = GameObject.FindGameObjectWithTag("Magic");
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
			EnemyController.ReceiveDamage(MagicModel.Effect);
        }
    }


}
