using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketHit : MonoBehaviour {
	public float weaponDamage;
	projectileController myPC;

	// Use this for initialization
	void Awake () {
		myPC = GetComponent<projectileController>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (weaponDamage);
			Debug.Log ("PLAYER HIT");
			myPC.removeForce ();
			Destroy (gameObject);
		}

//		if (other.tag == "Enemy") {
//			enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth> ();
//			hurtEnemy.addDamage (weaponDamage);
//		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (weaponDamage);

			Debug.Log ("PLAYER HIT");
			myPC.removeForce ();
			Destroy (gameObject);
		}
	}
}