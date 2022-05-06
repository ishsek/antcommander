using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

	Rigidbody2D myRB;
	public Vector2 projSpeed;

	// Use this for initialization
	void Awake () {
		myRB = GetComponent<Rigidbody2D> ();
		myRB.AddForce (projSpeed);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void removeForce() {
		myRB.velocity = new Vector2 (0, 0);
	}
}
