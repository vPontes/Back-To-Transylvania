using UnityEngine;
using System.Collections;

public class Cristal : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D colisor) {
		int vida;
		if (colisor.gameObject.tag == "Player") {
			var player = colisor.gameObject.GetComponent<Player>();

			vida = ((100-(player.contadorQueda*10))*player.vidaAtual)/100;
			player.RecuperaVida(vida);
			Destroy(gameObject);		
		}
	}
	
	/*void OnCollisionEnter2D(Collision2D colisor) {
		int vida;
		if (colisor.gameObject.tag == "Player") {
			
			var player = colisor.gameObject.GetComponent<Player>();

			vida = ((player.vidaAtual*(100-(player.contadorQueda*10)))/100);

			player.RecuperaVida(vida);

			Destroy(gameObject);
		}
	}
	*/
	
}