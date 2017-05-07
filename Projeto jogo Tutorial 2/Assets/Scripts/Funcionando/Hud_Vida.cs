using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud_Vida : MonoBehaviour {

	public int Vida;
	public GameObject Vida0;
	public GameObject Vida1;
	public GameObject Vida2;
	public GameObject Vida3;

	// Use this for initialization
	void Start () {
		Vida = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vida > 0) {
			if (Input.GetKeyDown ("-")) {
				Vida = Vida - 1;
			}
		}
		if (Vida <= 3) {
			if (Input.GetKeyDown ("=")) {
				Vida = Vida + 1;
			}
		}
	}

	void OnGUI ()
	{
		if (Vida == 0) {
			Vida0.SetActive (true);
			Vida1.SetActive (false);
			Vida2.SetActive (false);
			Vida3.SetActive (false);
		}

		if (Vida == 1) {
			Vida0.SetActive (false);
			Vida1.SetActive (true);
			Vida2.SetActive (false);
			Vida3.SetActive (false);
		}

		if (Vida == 2) {
			Vida0.SetActive (false);
			Vida1.SetActive (false);
			Vida2.SetActive (true);
			Vida3.SetActive (false);
		}

		if (Vida == 3) {
			Vida0.SetActive (false);
			Vida1.SetActive (false);
			Vida2.SetActive (false);
			Vida3.SetActive (true);
		}



	}
}
