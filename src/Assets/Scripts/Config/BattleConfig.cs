using UnityEngine;
using System.Collections;

public class BattleConfig : MonoBehaviour
{
	private GameObject player;
	private GameObject enemy;
	// private GameStorage gameStorage;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		// gameStorage = GetComponent<GameStorage> ();
	}
	

	void Update ()
	{
		// gameStorage.saveGame ();
		player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, 0f);
		enemy.transform.rotation = Quaternion.Euler(enemy.transform.rotation.eulerAngles.x, enemy.transform.rotation.eulerAngles.y, 0f);
	}
}

