using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float velocidade;
	public float forcaPulo;
	private bool estaNoChao;//variavel que identifica se personagem esta ou não no chão
	public Transform chaoVerificador; 
	public Transform player;//No tutorial devia ser spritePlayer porém deixei apenas como player.
	private Animator animator;	
	private bool attack;


	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator>();//No tutorial devia ser spritePlayer porém deixei apenas como player.
		//A variável spritePlayer servirá para pegar o conteúdo vinculado ao sprite heroi_sprite. Dele nós queremos ter o controle de tudo que fizemos na aba Animator. Por isso que fizemos dentro do método Start, ou seja, quando o personagem for criado, nós iremos jogar as configurações da aba Animator do heroi_sprite na variável animator do nosso script.
		//Vida

		//vida.guiText.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		//vida.guiText.text = "HP: " + vidaAtual + "/" + maxVida;
	
	}

	void Update () {
		Movimentacao();
		HandleInput ();
		HandleAttack ();
		ResetValues ();

	}

	private void HandleAttack(){//Função que quando acionada ativa a animação de ataque
	
		if (attack) {
			animator.SetTrigger ("attack");
		}
	
	}

	private void HandleInput(){//Função responsável por identificar o botão de ataque
		if (Input.GetKeyDown (KeyCode.Z)) {
			attack = true;

			//velocidade = Vector2.zero;
			
		}
	}

	private void ResetValues(){//Função para que o ataque não fique executando infinitamente. 
	
		attack = false;
	
	}

	void Movimentacao() {
		estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));//Este comando serve para jogar dentro do atributo estaNoChao verdadeiro ou falso.Onde será analisado se entre o personagem (transform.position) e o objeto chaoVerificador (chaoVerificador.position), existe algum conteúdo com o Layer Piso (1 << LayerMask.NameToLayer("Piso")). Caso exista será atribuído o valor verdadeiro no atributo estaNoChao.
		animator.SetFloat("movimento", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));

		//Verifica se esta no chao
		estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
		animator.SetBool ("chao", estaNoChao);

		if (!this.animator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
		
			if (Input.GetAxisRaw("Horizontal") > 0 ) {
				transform.Translate (Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2(0, 0);
			} 


			if (Input.GetAxisRaw("Horizontal") < 0 ) {
				transform.Translate (Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2(0, 180);
			}

			//Responsavel pelo pulo
			if (Input.GetButtonDown("Jump") && estaNoChao) {
				GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);////PARA NOVA VERSÃO DO UNITY USE GetComponet<Classe>(); GetComponent<RigidBody2D>()
			}
		
		}
			
	}


		
}
