using UnityEngine;
using System.Collections;

public class Musica : MonoBehaviour {
	
	public Texture2D musicOn; 
	public Texture2D musicOff; 
	public bool ativo;
	public bool musicaOn = false;
	// Use this for initialization
	void Start () {
		
	}


	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {
						musicaOn = true;
				}

	}
	
	// Update is called once per frame
	void Update () {
		if (musicaOn == true) {
			gameObject.audio.mute = false;
			gameObject.guiTexture.texture = musicOn;
		} else {
			gameObject.audio.mute = true;
			gameObject.guiTexture.texture = musicOff;
		}
	}
	
	void OnMouseDown() {
		ativo = !ativo;
	}
	
}
