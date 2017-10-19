using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour {

	private GameObject skill1;
	private GameObject skill2;
	private GameObject skill3;
	// private SkillModel skillModel;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		skill1 = GameObject.FindGameObjectWithTag ("Magic1");
		skill2 = GameObject.FindGameObjectWithTag ("Magic2");
		skill3 = GameObject.FindGameObjectWithTag ("Magic3");
	}
	

	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			Instantiate (skill1, new Vector2 (player.transform.position.x, player.transform.position.y), player.transform.rotation);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			Instantiate (skill2, new Vector2 (player.transform.position.x, player.transform.position.y), player.transform.rotation);
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			Instantiate (skill3, new Vector2 (player.transform.position.x, player.transform.position.y), player.transform.rotation);
		}
	}
}
