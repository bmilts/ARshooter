using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	// Enemy health
	public float health = 30f;
	AudioSource bloodSound;

	// Use this for initialization
	void Start () {

		AudioSource[] audio = GetComponents<AudioSource> ();
		bloodSound = audio [1];
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage){

		bloodSound.Play ();

		// Each hit lowers damage
		health -= damage;
		print (health);

		// Enemy destroy on health lower than 0
		if(health <= 0f){

			Die ();

		}
	
	}

	void Die (){

		// Destroy gameobject after 1 second
		Destroy (gameObject, 1f);
	}
}
