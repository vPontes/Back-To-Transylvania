using UnityEngine;
using System.Collections;


public class Esqueleto : MonoBehaviour {

		public float velocidade;
		public bool direcao;
		public float duracaoDirecao;//tempo fixado
	
		public Transform spritePlayer;
		private float tempoNaDirecao;//tempo q passou
		private Animator animator; 
		
		private bool atacou;
		private float tempoAtaque;

		void Start () {
			//animator = gameObject.transform.GetComponent ();
			animator = spritePlayer.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (direcao) {
			transform.eulerAngles = new Vector2(0, 0);
		} else {
			transform.eulerAngles = new Vector2(0, 180);
		}
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);
		
		tempoNaDirecao += Time.deltaTime;
		if (tempoNaDirecao >= duracaoDirecao) {
			tempoNaDirecao = 0;
			direcao = !direcao;
		}
	}
	
	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {

			animator.SetTrigger("atacou");

			var player = colisor.gameObject.transform.GetComponent<Player>();
			player.PerdeVida(30);
			
			colisor.gameObject.transform.Translate(-Vector2.right);
			
		}

		if (colisor.gameObject.tag == "pes") {
		
			Destroy(gameObject);

		
		}

	}
}
//http://jogosindie.com/tutorial-de-unity-2d-inimigo-parte-1/