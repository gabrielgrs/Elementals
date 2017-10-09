using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

	private bool ladoDireito;
	private Animator animator;

	[SerializeField]
	private float velocidade;

	private float tempoIdle;
	[SerializeField]
	private float duracaoIdle = 5f;

	private float tempoPatrulhar;
	[SerializeField]
	private float duracaoPatrulhar = 5f;

	private float tempoAtacar;
	[SerializeField]
	private float duracaoAtacar;

	public bool patrulhando;
	public bool atacar;

	public float playerDistancia;
	public float ataqueDistancia;
	public GameObject player;
	public GameObject prefabProjetil;
	public Transform spawner;

	public int dano;
	public int vida; 

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		ladoDireito = true;
		patrulhando = false;
		atacar = false;
	}
	
	// Update is called once per frame
	void Update () {
		MudarEstado ();

		playerDistancia = transform.position.x - player.transform.position.x;
		if (Mathf.Abs (playerDistancia) < ataqueDistancia) {
			atacar = true;
			patrulhando = false;
			Idle ();
			Atirar ();
		} else {
			MudarEstado ();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Limite") {
			MudarDirecao ();
		}

		if (collision.tag == "ProjetilPlayer") {
			Dano ();
		}
	}

	private void Dano() {
		vida -= dano;

		if (vida <= 0) {
			animator.SetTrigger ("Morrendo");
		} else {
			animator.SetLayerWeight (1, 1);
			animator.SetTrigger ("Dano");
		}
	}

	public void DesativarInimigo() {
		gameObject.SetActive (false);
	}

	public void SetLayerDano() { //camada volta a ser zero
		animator.SetLayerWeight(1, 0);
	}

	private void Mover() {
		transform.Translate (Direcao () * (velocidade * Time.deltaTime));

	}

	private Vector2 Direcao() {
		return ladoDireito ? Vector2.right : Vector2.left;
	}

	private void MudarDirecao() {
		ladoDireito = !ladoDireito;
		this.transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	//metodos de animacoes e acoes

	void Idle() {
		tempoIdle += Time.deltaTime;
		if (tempoIdle <= duracaoIdle) {
			animator.SetBool ("patrulhando", patrulhando);
			tempoPatrulhar = 0;
		} else {
			patrulhando = true;
		}
	}

	void Patrulhar() {
		tempoPatrulhar += Time.deltaTime;
		if (tempoPatrulhar <= duracaoPatrulhar) {
			animator.SetBool ("patrulhando", patrulhando);
			Mover ();
			tempoIdle = 0;
		} else {
			patrulhando = false;
		}
	}

	void Atirar() {
		if (playerDistancia < 0 && !ladoDireito || playerDistancia > 0 && ladoDireito) {
			MudarDirecao ();
		}
		if (atacar) {
			tempoAtacar += Time.deltaTime;
			if (tempoAtacar >= duracaoAtacar) {
				animator.SetTrigger("Atirando");
				tempoAtacar = 0; 
			}
		}
	}

	void MudarEstado() {
		if (!atacar) {
			if (!patrulhando) {
				Idle ();
			} else {
				Patrulhar ();
			}
		}
	}

	public void ResetarAtacar(){
		atacar = false;
	}

	public void InstanciarProjetil(){
		
		if (ladoDireito) {
			GameObject temp = Instantiate (prefabProjetil, spawner.position, spawner.rotation);
			temp.GetComponent<Bala> ().Inicializar (Vector2.right);
		} else {
			GameObject temp = Instantiate (prefabProjetil, spawner.position, Quaternion.Euler(new Vector3(0, 0, 180)));
			temp.GetComponent<Bala> ().Inicializar (Vector2.left);
		}
	}
}
