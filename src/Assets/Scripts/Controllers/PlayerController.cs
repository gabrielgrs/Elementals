using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject player;
	public PlayerModel model;
	public GameObject enemy;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		model = player.GetComponent<PlayerModel> ();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}
		

}
