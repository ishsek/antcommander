using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour {
	Rigidbody2D myRB;
	float randomScale;
	float randomRotation;
	float randomSpeed;

	// Use this for initialization
	void Awake () {
		randomScale = Random.Range (0.1f, 0.3f);
		randomSpeed = Random.Range (2, 5) +randomScale;
		randomRotation = Random.Range (-1, 1);
		myRB = GetComponent<Rigidbody2D> ();
		myRB.transform.localScale.Scale(new Vector3(randomScale, randomScale, randomScale));
		myRB.transform.Rotate (Vector3.forward * randomRotation);
	}
	
	// Update is called once per frame
	void Update () {
		myRB.transform.Rotate(Vector3.forward * randomRotation);
		myRB.AddForce(new Vector2(0, -randomSpeed));
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.transform.name == "Bottom Wall") {
			Destroy (gameObject);
			//			Debug.Log ("enemy 2 reset");
		}
	}
}
