using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float moveSpeed;

	Vector2 impulse;
	Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
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
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") {
			myRB.velocity *= -1;
			impulse.x *= -1;
			myRB.AddForce (impulse);
		}
	}


}
