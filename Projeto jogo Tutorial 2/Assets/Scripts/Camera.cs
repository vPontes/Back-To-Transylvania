using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 novaPosicao = new Vector3 (player.position.x, player.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, novaPosicao, Time.time);
	}
}


//Tutorial http://jogosindie.com/tutorial-unity-2d-5-cenario-parte-1/