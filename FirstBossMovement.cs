using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossMovement : MonoBehaviour {
	public float moveSpeed;
	int teleportDelay;
	public GameObject dashEffect;

	Vector2 impulse;
	Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
		teleportDelay = Random.Range (100, 500);

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
		if (Random.Range (0, 1000) < 5) {
			impulse.x *= -1;
		}
		myRB.AddForce (impulse);

		teleport ();
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") {
			myRB.velocity *= -1;
			impulse.x *= -1;
			myRB.AddForce (impulse);
		}
	}

	// Teleports boss to random spot on top of half of screen
	void teleport() {
		teleportDelay--;
		if (teleportDelay <= 0) {
			Instantiate (dashEffect, transform.position, transform.rotation);
			myRB.transform.position = new Vector2 (Random.Range (-10, 10), Random.Range (4, 7));
			teleportDelay = Random.Range (100, 500);
		}
	}
}
