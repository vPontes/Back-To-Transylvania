using UnityEngine;
using System.Collections;

public class BoladeFogo : MonoBehaviour {

	private float posicaoY = 0f;
	public bool destroibola = false;
	

	// Use this for initialization
	void Start () {
		if (destroibola == true) {
			Destroy (gameObject, 2f);
		}
		//rigidbody2D.AddForce (transform.up * 400f);
		//posicaoY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (posicaoY > transform.position.y) { //Descendo
			transform.eulerAngles = new Vector2(180, 0);
		}
		posicaoY = transform.position.y;
	
	}


	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {
			var player = colisor.gameObject.GetComponent <Player>();
			player.PerdeVida(10);
		}
		Destroy (gameObject);

		}

}

// Tutorial http://jogosindie.com/tutorial-unity-2d-5-cenario-parte-1/