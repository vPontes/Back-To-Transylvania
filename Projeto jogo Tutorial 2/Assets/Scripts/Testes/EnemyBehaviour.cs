using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {


	private Rigidbody2D rb;
	private Transform tr;
	private Animator an;
	public Transform verificaParede;
	public Transform verificaChao;

	private bool estaNaParede;
	private bool estaNoChao;
	private bool viradoParaDireita;

	public float velocidade;
	public float raioValidaParede;
	public float raioValidaChao;

	public LayerMask solido;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<Transform>(); 
		an = GetComponent<Animator>();

		viradoParaDireita = true;
	}
	// Use this for initialization
	void EnemyMovements(){
	
		estaNaParede = Physics2D.OverlapCircle (verificaParede.position, raioValidaParede, solido);
		estaNoChao = Physics2D.OverlapCircle (verificaChao.position, raioValidaChao, solido);

		if ((!estaNoChao || estaNaParede) && viradoParaDireita) {
			flip ();
		}

		else if ((!estaNoChao || estaNaParede) && !viradoParaDireita) {
			flip ();
		}
		if (estaNoChao) {

			rb.velocity = new Vector2(velocidade, rb.velocity.y);

		}
	
	}

	void flip(){
		viradoParaDireita = !viradoParaDireita;
		tr.localScale = new Vector2 (-tr.localScale.x, tr.localScale.y);
		velocidade = velocidade * -1;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMovements();
	}
}
