using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionWithCamera : MonoBehaviour {

	public bool zombieCollision;

	// Time between attacks
	float timer;
	int timeBetweenAttack;

	private GameControllerScript gameController;
	AudioSource attackSound;

	// Use this for initialization
	void Start () {

		// Two second timer between attacks
		timeBetweenAttack = 2;

		// CONNECT TO GAMECONTROLLER SCRIPT
		// Create new gameobject find with tag 
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null){
			
			gameController = gameControllerObject.GetComponent<GameControllerScript> ();
		
		}

		// Audio array for various audio sources
		AudioSource[] audio = GetComponents<AudioSource> ();
		attackSound = audio [0];

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		// TEST timer print (timer);

		// enemy can only attack player every two seconds
		if (zombieCollision && timer >= timeBetweenAttack) {
		
			Attack ();
		
		}
		
	}

	// If enemy collides with main camera DO
	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "MainCamera"){
		
			zombieCollision = true;

			// Collision testing
			//Debug.Log ("enter");

		}
	}

	// If main camera moves away from enemy DO
	void OnCollisionExit(Collision col){

		if(col.gameObject.tag == "MainCamera"){

			zombieCollision = false;
		
			// Collision testing
			//Debug.Log ("exit");

		}
	}

	void Attack(){
	
		// Reset timer to allow for break between attack
		timer = 0;

		// Access animator
		GetComponent<Animator> ().Play ("attack");
		gameController.zombieAttack (zombieCollision);

		// Play zombie scream
		attackSound.Play ();
		
	}


}
