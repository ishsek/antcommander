using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {
	public float enemyMaxHealth;
	float currentHealth;
	public GameObject deathFX;
	GameObject mySpawner; 
	EnemySpawner mySpawnerScript;
	public Slider bossHealthSlider;

	// Use this for initialization
	void Start () {
		if (bossHealthSlider != null) {
			bossHealthSlider.maxValue = enemyMaxHealth;
		}
		currentHealth = enemyMaxHealth;
		mySpawner = GameObject.FindGameObjectWithTag ("Spawner");
		mySpawnerScript = mySpawner.GetComponent<EnemySpawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bossHealthSlider != null) {
			bossHealthSlider.value = currentHealth;
		}
	}

	public void addDamage(float damage) {
		currentHealth -= damage;
		Debug.Log ("BOSS HP: " + currentHealth);
		if (currentHealth <= 0) 
			makeDead ();
	}

	void makeDead() {
		mySpawnerScript.addDestroyedCount ();
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
