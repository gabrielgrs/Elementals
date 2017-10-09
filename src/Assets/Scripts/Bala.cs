using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bala : MonoBehaviour {

	[SerializeField]
	private float velocidade;

	[SerializeField]
	private GameObject explosao;

	private Vector2 direcao;
	private float tempo = 0.08f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		//direcao = Vector2.right; // vetor em 2d (1,0)
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		rb.velocity = direcao * velocidade;
	}

	public void Inicializar(Vector2 _direcao) {
		direcao = _direcao; 
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D outro) {
		if(outro.gameObject.tag == "Inimigo"){
			if(explosao!=null)
			explosao.SetActive(true);

			StartCoroutine ("Destruir");
		}

		if(outro.gameObject.tag == "Player"){	
			StartCoroutine ("Destruir");
		}
	}

	IEnumerator Destruir () {
		yield return new WaitForSeconds (tempo);
		Destroy (gameObject);
	}
}