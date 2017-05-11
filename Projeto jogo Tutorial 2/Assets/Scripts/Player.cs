using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float velocidade;
	public float forcaPulo;
	private bool estaNoChao;
	public Transform chaoVerificador;
	public Transform spritePlayer;
	private Animator animator;
	private bool attack;
	public GameObject vida;
	public int maxVida;
	private int vidaAtual;

	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator>();

		//Vida
		vidaAtual = maxVida;
		vida.guiText.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);

		//Agora se eu quisesse um verde normal, poderia usar: vida.guiText.color = Color.green;

		vida.guiText.text = "HP: " + vidaAtual + "/" + maxVida;

	}
	
	// Update is called once per frame
	void Update () {
		Movimentacao();
	}


	public void PerdeVida(int dano) {
		vidaAtual -= dano;
		
		if (vidaAtual <= 0) {

			Application.LoadLevel(Application.loadedLevel);
		} 
		
		if ((vidaAtual * 100 / maxVida) < 30) {
			vida.guiText.color = Color.red;
		}
		
		vida.guiText.text = "HP: " + vidaAtual + "/" + maxVida;
	}

				
	public void RecuperaVida(int recupera) {
		vidaAtual += recupera;
		
		if (vidaAtual > maxVida) {
			vidaAtual = maxVida;
		}
		
		if ((vidaAtual * 100 / maxVida) >= 30) {
			vida.guiText.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		}
		
		vida.guiText.text = "HP: " + vidaAtual + "/" + maxVida;
	}

	
	void Movimentacao() {


		animator.SetFloat("andar", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));//andar e o nme do trigger, precisa ser exatamente o mesmo nome

						if (Input.GetAxisRaw ("Horizontal") > 0) {
								transform.Translate (Vector2.right * velocidade * Time.deltaTime);
								transform.eulerAngles = new Vector2 (0, 0);
						}

						if (Input.GetAxisRaw ("Horizontal") < 0) {
								transform.Translate (Vector2.right * velocidade * Time.deltaTime);
								transform.eulerAngles = new Vector2 (-10, 180);
						}


				
		estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));

		animator.SetBool("pular", estaNoChao);//Piso e o nome da layer para identificar se o personagem esta no chao

		if (Input.GetButtonDown("Jump") && estaNoChao) {
			rigidbody2D.AddForce(transform.up * forcaPulo);
		}
	}
}