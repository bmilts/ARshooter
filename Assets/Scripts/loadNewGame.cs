using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loadNewGame : MonoBehaviour {

	public Button newGame;

	// Use this for initialization
	void Start () {

		newGame.onClick.AddListener (loadGame);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void loadGame(){

		SceneManager.LoadScene ("UnityARKitScene");

	}
}
