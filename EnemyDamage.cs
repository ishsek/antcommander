using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	public float damage;
	public float fireRate;
	float timeToFire;
	public GameObject bullet;
	public Transform blasterTip;


	// Use this for initialization
	void Awake () {
		timeToFire = fireRate;
	}
	
	// Update is called once per frame
	void Update () {
		timeToFire--;
		if (timeToFire <= 0) {
			fireRocket ();
			timeToFire = fireRate;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Player") {
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (damage);
		}	
	}

	void fireRocket() {
		Instantiate(bullet, blasterTip.position, Quaternion.Euler(new Vector3(0,0,0)));
	}	
}
