using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// (Allow zombie to move forward * handle speed)
		transform.Translate(Vector3.forward * Time.deltaTime * 0.3f);

		// Rotate the camera every frame so it keeps looking at the target
		// Target is main camera
		transform.LookAt(Camera.main.transform.position);

		// Stop zombie from movie 
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

	}
}
