using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {
	public float fullHealth;
	float currentHealth;
	public GameObject deathFX;

	PlayerBehaviour controlMovement;
	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<PlayerBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage) {
//		if (damage <= 0)
//			return;
		currentHealth -= damage;
		if (currentHealth <= 0) {
			makeDead ();
		}
	}

	public void makeDead() {
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
