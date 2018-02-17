using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponPickUp : MonoBehaviour {

	public Button pickUpBtn;
	public GameObject weapon1;

	// Use this for initialization
	void Start () {

		pickUpBtn.onClick.AddListener (weapon1True);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void weapon1True(){

		weapon1.gameObject.SetActive (true);
	}
}
