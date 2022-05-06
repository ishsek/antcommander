using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : MonoBehaviour {
	 Transform target;
	public float moveSpeed;
	Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("player") != null) {
			target = GameObject.Find ("player").transform;
			// Rotate the camera every frame so it keeps looking at the target
			myRB.AddForce ((target.transform.position - myRB.transform.position).normalized * moveSpeed);

			Vector3 vectorToTarget = target.transform.position - transform.position;
			float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * moveSpeed);
		}

	}
}
