using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Transform player;
	private Vector3 offset;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		offset = transform.position - player.transform.position;
	}
	

	void LateUpdate () {
		followPlayer ();
	}

	void followPlayer() {
		transform.position = player.transform.position + offset;
	}


}
