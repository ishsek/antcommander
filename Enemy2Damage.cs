using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Damage : MonoBehaviour {
	public float damage;
	public float fireRate;
	float timeToFire;


	// Use this for initialization
	void Start () {
		//nextDamage = 0f;

	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (damage);
		}	
	}
}
