using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float Velocidade;
	public float ForcaPulo;
	public Rigidbody2D rb;

	public int Vida;

	public GameObject magics;
	public GameObject gun;

	public GameObject enemy;



	// Use this for initialization
	void Start () {
		Velocidade = 10f;
		ForcaPulo = 200f;
		Vida = 10;

		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			transform.Translate (Vector2.right * Velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		} 
		if (Input.GetAxisRaw ("Horizontal") < 0) {
			transform.Translate (Vector2.right * Velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (transform.up * ForcaPulo);
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			Vida -= 1;
			print (Vida);
			if (Vida < 1) {
				print ("Morreu");
			}
		}

		// if (magics.

		if (Input.GetKeyDown (KeyCode.C)) {
			Instantiate (magics, new Vector2 (gun.transform.position.x, gun.transform.position.y), gun.transform.rotation);
			magics.transform.Translate (new Vector2 (2.5f * Time.deltaTime, 0));
		}
	}		

	void OnTriggerExit2D(Collider2D _outros) { 
		if ( _outros.gameObject.CompareTag("Tag") ) { 
			// destroi objeto
		}
	}
}
