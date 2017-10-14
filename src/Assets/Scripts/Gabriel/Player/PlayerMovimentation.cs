using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimentation : MonoBehaviour {
	private float horizontalMove;
	private float moveSpeed;
	private float jumpForce;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		// Pega o componente RigidBody2D
		rb2d = GetComponent<Rigidbody2D>();
		// Define velocidade de movimentação
		moveSpeed = 5f;
		// Define força do pulo
		jumpForce = 100f;

	}
	
	// Update is called once per frame
	void Update () {
		moveInX ();
		// jump ();
	}


	void moveInX() {
		// Move para a direita
		if (Input.GetAxisRaw("Horizontal") > 0) {
			transform.Translate (moveSpeed * Vector2.right * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		} 
		// Move para a esquerda
		if (Input.GetAxisRaw("Horizontal") < 0) {
			transform.Translate (moveSpeed * Vector2.right *  Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}
	}

	void jump() {
		if (/* onFloor()  && */ Input.GetButtonDown("jump")) {
			rb2d.AddForce (transform.up * jumpForce);
		}
	}

	private bool onFloor() {
		// GameObject floor = GameObject.FindGameObjectWithTag("Floor");
		var onFlor = true;
		if (onFlor) {
			return true;
		} else {
			return false;
		}

	}
}
