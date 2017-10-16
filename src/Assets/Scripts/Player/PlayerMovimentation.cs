using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimentation : MonoBehaviour {
	private float horizontalMove;
	private float moveSpeed;
	private float jumpForce;

    private bool rightSide;
    private bool inFloor;

	private Rigidbody2D rb2d;

    public GameObject floorCheker;

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();

		moveSpeed = 5f;

		jumpForce = 100f;
        // Define direção do personagem
		rightSide = true;
        inFloor = true;
        

	}
	
	// Update is called once per frame
	void Update () {
		moveInX ();
		jump ();
	}


	void moveInX() {
		// Move para a direita
		if (Input.GetAxisRaw("Horizontal") > 0) {
			transform.Translate (moveSpeed * Vector2.right * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
			rightSide = true;
		} 
		// Move para a esquerda
		if (Input.GetAxisRaw("Horizontal") < 0) {
			transform.Translate (moveSpeed * Vector2.right *  Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
			rightSide = false;
		}
	}

	void jump() {
        inFloor = Physics2D.Linecast(transform.position, floorCheker.transform.position, 1 << LayerMask.NameToLayer("Piso"));
        if (inFloor && Input.GetButtonDown("jump")) {
            rb2d.AddForce(transform.up * jumpForce); // rb2d.AddForce (0, jumpForce);
        }
	}

}
