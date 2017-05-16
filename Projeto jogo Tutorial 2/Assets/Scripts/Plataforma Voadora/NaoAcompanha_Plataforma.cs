using UnityEngine;
using System.Collections;

public class NaoAcompanha_Plataforma : MonoBehaviour {
	public float velocidade;
	public float duracaoPosicao;
	public float tempo;
	public bool posicao;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		//Aumenta o tempo que esta na posiçao atual
		tempo += Time.deltaTime;
		
		//Se o tempo 
		if (tempo >= duracaoPosicao) {
			//Zera contagem
			tempo = 0;
			
			//Muda a posiçao
			if (posicao) {
				posicao = false;
			} else {
				posicao = true;
			}
		}
		//movimenta
		if (posicao) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
		} else {
			transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
		}	
	}
}


//http://jogosindie.com/tutorial-de-unity-2d-6-cenario-parte-2/