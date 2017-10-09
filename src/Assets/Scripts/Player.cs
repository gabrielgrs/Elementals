using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2D;
	private Animator animator;

	//variáveis
	float horizontal;
	private bool ladoDireito;

	public LayerMask plataforma;
	public Vector2 pontoColisaoPiso = Vector2.zero;

	public bool estaNoChao;
	public float raio;
	public Color debugCorColisao = Color.red;

	public float forcaPulo = 400f; 
	public bool pular;

	private bool acao;

	[SerializeField]
	private float velocidade = 0;

	[SerializeField]
	private GameObject posicaoProjetil;
	[SerializeField]
	private GameObject projetil;


	public int vida = 3;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		ladoDireito = transform.localScale.x > 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		horizontal = Input.GetAxis ("Horizontal");	
		Movimentar (horizontal);
		MudarDirecao (horizontal);
		EstaNoChao ();
		ControlarEntradas ();
		controlarLayers ();
		Acao ();
	}

	void Update(){
		Resetar ();
	}

	private void EstaNoChao() {
		var pontoPos = pontoColisaoPiso; 
		pontoPos.x += transform.position.x;
		pontoPos.y += transform.position.y;
		estaNoChao = Physics2D.OverlapCircle(pontoPos, raio, plataforma);
		Cair ();
	}

	private void Pular() {

		rb2D.gravityScale = 1.6f;
		if (estaNoChao && rb2D.velocity.y <= 0) {
			rb2D.AddForce (new Vector2 (0, forcaPulo)); 
			animator.SetTrigger ("pular");
		}
	}

	private void Cair() {
		if (!estaNoChao && rb2D.velocity.y <= 0) {
			animator.SetBool ("cair", true);
			animator.ResetTrigger ("pular");
		}
		if (estaNoChao) {
			animator.SetBool ("cair", false);
		}
	}

	private void ControlarEntradas(){
		if(Input.GetButtonDown("Jump")){
			Pular();
		}

		if (Input.GetKeyDown (KeyCode.LeftAlt)) {
			acao = true; 
		}
	}

	void Resetar(){
		acao = false;
	}

	private void Movimentar (float h) {

		if (!animator.GetCurrentAnimatorStateInfo (0).IsTag ("Atirar")) {
			rb2D.velocity = new Vector2(h*velocidade,rb2D.velocity.y); //x da propriedade transform - tem modificações
		}

		animator.SetFloat ("velocidade", Mathf.Abs(h));

		if (rb2D.velocity.y == 0) {
			rb2D.gravityScale = 1.0f;
		}
	}

	private void MudarDirecao (float horizontal) {
		if (horizontal > 0 && !ladoDireito || horizontal < 0 && ladoDireito) {
			ladoDireito = !ladoDireito;
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

	void OnDrawGizmos() {

		Gizmos.color = debugCorColisao;
		var pontoPos = pontoColisaoPiso; 
		pontoPos.x += transform.position.x;
		pontoPos.y += transform.position.y;

		Gizmos.DrawWireSphere (pontoPos, raio);
	}

	void Acao(){
		if (acao && !animator.GetCurrentAnimatorStateInfo (0).IsTag ("Atirar")) {
			animator.SetTrigger ("atirar");

			rb2D.velocity = Vector2.zero;
			AcaoAtirar ();
		}
	}

	private void AcaoAtirar() {		

		if (ladoDireito) {
			GameObject tmpProjetil = (GameObject)(Instantiate (projetil, posicaoProjetil.transform.position, Quaternion.identity));
			tmpProjetil.GetComponent<Bala> ().Inicializar (Vector2.right);
		} else {
			GameObject tmpProjetil = (GameObject)(Instantiate (projetil, posicaoProjetil.transform.position, Quaternion.Euler(new Vector3(0, 0, 180))));
			tmpProjetil.GetComponent<Bala> ().Inicializar (Vector2.left);
		}
	}

	void controlarLayers () {
		if (!estaNoChao) {
			animator.SetLayerWeight (1, 1);
		} else {
			animator.SetLayerWeight (1, 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("ProjetilInimigo")) {
			Destroy (collision.gameObject);
			vida--;
			if (vida > 0) {				
				animator.SetLayerWeight (2, 1);
				animator.SetTrigger ("Dano");
			} else {
				animator.SetTrigger ("Morrer");
			}
		}
	}

	public void SetLayerDano(){
		animator.SetLayerWeight (1, 0);
	}
}