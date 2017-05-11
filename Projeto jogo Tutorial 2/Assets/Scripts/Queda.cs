using UnityEngine;
using System.Collections;

public class Queda : MonoBehaviour {
	private Transform player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D colisor) {

		if (colisor.gameObject.tag == "Player") {
			var player = colisor.gameObject.GetComponent<Player>();
			player.PerdeVida(player.maxVida);
		}
	}



}

//Tutorial http://jogosindie.com/tutorial-unity-2d-5-cenario-parte-1/