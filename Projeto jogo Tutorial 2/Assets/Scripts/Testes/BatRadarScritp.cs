﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatRadarScritp : MonoBehaviour {


	private BatIa script;

	// Use this for initialization
	void Start () {
		script = (BatIa)GetComponentInParent(typeof(BatIa));
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			script.lostPlayer = false;
			script.canFly = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			script.BackToHome ();
			script.lostPlayer = true;
			script.canFly = true;
		}
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
