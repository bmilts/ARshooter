using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootEnemy : MonoBehaviour {

	public Button shootBtn;
	public Camera fpsCam;
	public float damage = 10f;
	public GameObject bloodEffect;
	public GameObject shootEffect;
	public int forceAdd = 300;
	AudioSource shootSound;
	AudioSource reloadSound;
	public Text ammo1Text;
	public Text ammo2Text;
	public int ammo1;
	public int ammo2;
	private bool ammoIsEmpty;
	public ParticleSystem muzzleFlash;
	public GameObject pistolStart;
	private bool reloadCheck;
	public GameObject shell;


	// Use this for initialization
	void Start () {

		// On clicking shoot button
		shootBtn.onClick.AddListener (onShoot);

		// Audio source array for gun sounds
		AudioSource[] audio = GetComponents<AudioSource> ();
		shootSound = audio [0];
		reloadSound = audio [1];

		ammo1 = 20;
		ammo2 = 100;

		reloadCheck = true;

	}

	// Wait seconds to reload amount so that reload animation happens before
	IEnumerator waitForReload(){
		yield return new WaitForSeconds(3f);
		reloadCheck = true;
	}
	
	void onShoot(){

		// AMMO
		// Only if ammo is not empty can we shoot
		if (!ammoIsEmpty) {

			if (ammo1 == 1) {

				ammo1 = 21;
				pistolStart.GetComponent<Animator> ().SetTrigger("reload");
				// Cannot shoot if reload check is false
				reloadCheck = false;
				StartCoroutine (waitForReload());
				reloadSound.Play ();

			}
				
			// Decrease ammo on shoot
			ammo1 -= 1;
			// Convert ammo 1 back to string to display
			string ammo1String = (ammo1).ToString ();
			ammo1Text.text = ammo1String;

			ammo2 -= 1;
			string ammo2String = (ammo2).ToString ();
			ammo2Text.text = "/" + ammo2String;

			if (ammo2 == 0 && reloadCheck) {

				ammoIsEmpty = true;
				ammo1 = 0;
				// Overide ammo outside
				string ammo11String = (ammo1).ToString ();
				ammo1Text.text = ammo11String;
			}

			// RAYCAST FOR LOGIC AND DAMAGE

			RaycastHit hit;
			// Logic to shoot (origin(Starting point of the bullet), direction, hitInfo(if hit is true hit infor will contain more about where hit))
			if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit)) {

				// Connect to script enemy
				enemy target = hit.transform.GetComponent<enemy> ();

				// Target take 
				if (target != null) {

					target.TakeDamage (damage);
					// Start blood effect on damage taken
					GameObject bloodStart = Instantiate (bloodEffect, hit.point, Quaternion.LookRotation (hit.normal));
					// Stop blood effect
					Destroy (bloodStart, 0.2f);
				} else {
					// Show shooting object for zombie miss
					GameObject shootStart = Instantiate (shootEffect, hit.point, Quaternion.LookRotation (hit.normal));
					Destroy (shootStart, 0.2f);
				} 

				// On hit adds force backwards to enemy
				if (hit.rigidbody != null) {

					hit.rigidbody.AddForce (-hit.normal * forceAdd);

				}
					
			}

			// SOUND AND ANIMATION PLAY

			muzzleFlash.Play ();	
			pistolStart.GetComponent<Animator> ().Play("Fire");
			shootSound.Play ();
		
			// BULLET SHELL LOADING 

			Vector3 position = GameObject.FindGameObjectWithTag ("positionPistol").transform.position;
			Quaternion rotation = Quaternion.Euler (0,0,0);

			Instantiate(shell, position, rotation);
		}

	}
}
