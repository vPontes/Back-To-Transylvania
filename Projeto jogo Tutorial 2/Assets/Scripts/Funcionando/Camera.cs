using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {


	public Transform player;
	public float smooth = 0.5f;
	private Vector2 velocidade;


	// Use this for initialization
	void Start () {
		velocidade = new Vector2(0.0f, 0.99f);

	}

	// Update is called once per frame
	void Update () {
		Vector2 novaPosicao2D = Vector2.zero;
		novaPosicao2D.x = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocidade.x, smooth); //velocidade da camera em x

		novaPosicao2D.y = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocidade.y, smooth); //velocidade da camera em y

		Vector3 novaPosicao = new Vector3(novaPosicao2D.x, novaPosicao2D.y, transform.position.z);

		transform.position = Vector3.Slerp(transform.position, novaPosicao, Time.time);//interpolação nao linear
	}
}
