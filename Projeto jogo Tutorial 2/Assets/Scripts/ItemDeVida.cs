using UnityEngine;
using System.Collections;

public class ItemDeVida : MonoBehaviour {
	public int vida;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {
			var player = colisor.gameObject.GetComponent<Player>();
			player.RecuperaVida(vida);
			Destroy(gameObject);
		}
	}


}
//http://jogosindie.com/tutorial-de-unity-2d-controle-da-vida-personagem/