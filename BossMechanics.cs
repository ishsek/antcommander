using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanics : MonoBehaviour {
	// Boss firing variables
	public float damage;
	public float fireRate;
	float timeToFire;
	public int blasts;
	public int blastSpeed;
	int blastsRemaining;
	public GameObject bullet;
	public Transform blasterTip1;
	public Transform blasterTip2;

	// Boss movement and damage variables
	public float moveSpeed;
	Vector2 impulse;
	Rigidbody2D myRB;

	// Boss Phase variables
	int phase;
	public int phaseChangeTime;
	int phaseSwitchTimer;

	// Use this for initialization
	void Awake () {
		// Start at initial phase
		phase = 0;
		phaseChangeTime *= 60;
		phaseSwitchTimer = phaseChangeTime;

		// Firing starter variables
		timeToFire = fireRate;
		blastsRemaining = blasts;

		// movement starter variables
		myRB = GetComponent<Rigidbody2D> ();

		if (Random.Range (0, 10) < 5) {
			impulse = new Vector2 (-moveSpeed, 0);
			myRB.AddForce (impulse);
		} else {
			impulse = new Vector2 (moveSpeed, 0);
			myRB.AddForce (impulse);
		}
	}


	// Update is called once per frame
	void Update () {
		if (phase == 0) {
			phase0Mechanics ();
		} else if (phase == 1) {
			phase1Mechanics ();
		}
	}

	void phase0Mechanics() {
		// Update firing pattern
		timeToFire--;
		if (timeToFire <= 0 && blastsRemaining > 1) {
			fireRocket ();
			timeToFire = fireRate/blastSpeed;
			blastsRemaining--;
		} else if (timeToFire <= 0 && blastsRemaining == 1) {
			fireRocket();
			timeToFire = fireRate;
			blastsRemaining = blasts;
		}

		// Update movement
//		if (Random.Range (0, 1000) < 5) {
//			impulse.x *= -1;
//		}
		myRB.AddForce (impulse);

		phaseSwitchTimer--;
		// Switch phase
		if (phaseSwitchTimer <= 0) {
			phase = 1;
			phaseSwitchTimer = phaseChangeTime/2;
		}
	}

	// First phase mechanics
	void phase1Mechanics() {
		myRB.AddForce (new Vector2(0, -100));
		timeToFire--;
		if (timeToFire <= 0) {
			if (Random.Range (0, 10) > 1) {
				fireRocket ();
			}
			timeToFire = fireRate/blastSpeed;
		}
		phaseSwitchTimer--;
		// Switch phase
		if (phaseSwitchTimer <= 0) {
			phase = 0;
			myRB.position = (new Vector2(0, 12));
			myRB.AddForce(new Vector2(0, -70));
			phaseSwitchTimer = phaseChangeTime;
		}
	}

	// Check collision with player
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (damage);
		}	
	}

	// check collision with walls
	void OnTriggerEnter2D(Collider2D other) {
		if (phase == 0) {
			if (other.gameObject.transform.name == "Left Wall" || other.gameObject.transform.name == "Right Wall") {
				myRB.velocity *= -1;
				impulse.x *= -1;
				myRB.AddForce (impulse);
			}
		}
	}

	// Fire projectiles
	void fireRocket() {
		if (phase == 0) {
			Instantiate (bullet, blasterTip1.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			Instantiate (bullet, blasterTip2.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
		} else if (phase == 1) {
			Instantiate (bullet, new Vector2(Random.Range(-10, 11), Random.Range(9, 10)), Quaternion.Euler (new Vector3 (0, 0, 0)));
		}
	}	


}
