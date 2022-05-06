using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour {
	public float moveSpeed;

	Vector2 impulse;
	Rigidbody2D myRB;
	public float changeDelay;
	float changeTimer;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		impulse = new Vector2 (Random.Range(-moveSpeed, moveSpeed), -moveSpeed);
		myRB.AddForce (impulse);
	}

	// Update is called once per frame
	void Update () {
		changeTimer--;
		if (changeTimer <= 0) {
			impulse = new Vector2 (Random.Range(-moveSpeed, moveSpeed), -moveSpeed);
			changeTimer = changeDelay;
		}
		myRB.AddForce (impulse);

		Vector2 v = myRB.velocity;
		float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg + 90;
		myRB.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.transform.name == "Bottom Wall") {
			transform.position = new Vector3 (Random.Range(-9, 9), Random.Range(9, 10), 0);
//			Debug.Log ("enemy 2 reset");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.transform.name == "Left Wall" || other.gameObject.transform.name == "Right Wall") {
			impulse.x *= -1;
			myRB.AddForce (impulse);
		}
	}


}
