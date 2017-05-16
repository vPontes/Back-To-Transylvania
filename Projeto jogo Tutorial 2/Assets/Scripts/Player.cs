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
	public int vidaAtual;
	public int tempoSpeed;
	public int contadorQueda;
	public int contadorQuedaAuxiliar = 1;

	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator>();
		contadorQueda = 0;
		//Vida
		vidaAtual = 0;
		vida.guiText.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);

		//Agora se eu quisesse um verde normal, poderia usar: vida.guiText.color = Color.green;
		
		//vida.guiText.text = "Pontos: " + vidaAtual + "/ Mortes: " + contadorQueda;
		vida.guiText.text = "Pontos: " + vidaAtual;

	}

	
	// Update is called once per frame
	void Update () {

		if (velocidade <= 10 && velocidade != 3) {
			tempoSpeed --;		
		}
		if (tempoSpeed == 0) {
			velocidade = 3;		
		}
		Movimentacao();
	}

	public void QuedaCastlevania(){
		contadorQueda++;
		transform.position = new Vector3 (-4, 2);
	}

	public void QuedaMario(){
		contadorQueda ++;
		transform.position = new Vector3 (3, -70);
	}
	
	public void teletransporte0(){
		//Application.LoadLevel(Application.loadedLevel);
		contadorQueda = 0;
		transform.position = new Vector3 (-4, 2);
	}

	public void teletransporte1(){	
		contadorQueda = 0;
		transform.position = new Vector3 (3, -70);
	}
	

	public void teletransporte2(){
		contadorQueda = 0;
		transform.position = new Vector3 (5, -190);
	}



	public void SpeedUp(){
		tempoSpeed = 100;
			velocidade = 10;

		
	}


	public void PerdeVida(int dano) {
		vidaAtual -= dano;
		
		if (vidaAtual <= 0) {
			vidaAtual = 0;
			//Application.LoadLevel(Application.loadedLevel);
		} 
		
		if ((vidaAtual * 100 / maxVida) < 30) {
			vida.guiText.color = Color.red;
		}
		
		vida.guiText.text = "Pontos: " + vidaAtual;
	}	//"HP: " + vidaAtual + "/" + maxVida;

				
	public void RecuperaVida(int recupera) {
		vidaAtual += recupera;
		
		//if (vidaAtual > maxVida) {
		//	vidaAtual = maxVida;
		//}
		
		if ((vidaAtual * 100 / maxVida) >= 30) {
			vida.guiText.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		}
		
		
		vida.guiText.text = "Pontos: " + vidaAtual;
		//vida.guiText.text = "Pontos: " + vidaAtual;
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
	

