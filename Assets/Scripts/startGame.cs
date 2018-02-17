using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

public class startGame : MonoBehaviour {

	public Button startBtn;
	// Reference to ARkit script
	private UnityARHitTestExample UnityARHitTestExample;
	public Image crosshair;

	// Use this for initialization
	void Start () {

		// Onclick start button to start new game
		startBtn.onClick.AddListener(startNewGame);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void startNewGame(){
	
		UnityARHitTestExample = GetComponent<UnityARHitTestExample> ();
		Destroy (UnityARHitTestExample);
		startBtn.gameObject.SetActive(false);
		crosshair.gameObject.SetActive (true);

	}
}
