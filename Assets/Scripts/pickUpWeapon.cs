using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpWeapon : MonoBehaviour {

	public GameObject pickUpBtn;
	public GameObject crossHair;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){

		if(col.gameObject.name == "pistol"){

			pickUpBtn.gameObject.SetActive (true);
			crossHair.gameObject.SetActive (false);

		}

	}

	void OnCollisionExit(Collision col){
	
		if(col.gameObject.name == "pistol"){

			pickUpBtn.gameObject.SetActive (false);
			crossHair.gameObject.SetActive (true);

		}

	}


}
