using UnityEngine;
using System.Collections;

public class TeleTrasnporte : MonoBehaviour {
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D colisor) {
		
		var player = colisor.gameObject.GetComponent<Player>();
		if (colisor.gameObject.tag == "Player") {
			
			var playerObject = colisor.gameObject.GetComponent<Player>();
			playerObject.teletransporte1();
		}
	}
	
	
	
}

//Tutorial http://jogosindie.com/tutorial-unity-2d-5-cenario-part