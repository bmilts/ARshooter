using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

	public GameObject bloodyScreen;
	public Text healthText;
	public int health;

	// Use this for initialization
	void Start () {

		// On start set health to 100
		health = 100;

	}
	
	// Update is called once per frame
	void Update () {

		// Die on health being less than or equal to zero
		if(health <= 0){

			SceneManager.LoadScene ("GameOver");

		}
		
	}

	public void zombieAttack(bool zombieCollision){

		// enable bloody screen on attack method
		bloodyScreen.gameObject.SetActive(true);
		StartCoroutine (WaitTwoSeconds ()); // Two second gap
		health -= 5;

		// convert health number to string
		string stringHealth = (health).ToString();
		healthText.text = "" + stringHealth;
	
	}

	IEnumerator WaitTwoSeconds(){
		// Wait 2 seconds
		yield return new WaitForSeconds (2f);
		// Reset screen back to normal
		bloodyScreen.gameObject.SetActive (false);
	}

}
