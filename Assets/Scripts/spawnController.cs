using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class spawnController : MonoBehaviour {

	public GameObject zombie;
	public Button startBtn;

	// Use this for initialization
	void Start () {

		startBtn.onClick.AddListener (startInvoke);
	}

	// Update is called once per frame
	void Update () {

	}

	// Place zombies on house placement then reapeat 
	void startInvoke(){

		InvokeRepeating ("spawn", 0f, 5f);

	}

	void spawn(){
		// Place zombie at random vector x,y,z
		Vector3 position = new Vector3 (Random.Range(-10f, 10f), Random.Range(-3f, 3f), Random.Range(-10f, 10f));
		// Place a zombie at above position and relevant rotation
		Instantiate (zombie, position, Quaternion.Euler(0,0,0));

	}
}
