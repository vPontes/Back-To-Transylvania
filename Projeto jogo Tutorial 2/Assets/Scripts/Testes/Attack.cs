using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	Animator anim;
	public float IntervaloDeAtaque;
	private float PorximoAtaque;// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("w") && Time.time > PorximoAtaque) {
			Atacando ();
		}
	}


	void Atacando(){
	
		anim.SetTrigger ("player_atacando");
		PorximoAtaque = Time.time + IntervaloDeAtaque;
	}

}
