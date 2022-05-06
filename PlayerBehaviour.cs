using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {
	
	public float fLeft;
	public float fRight;
	public float fUp;
	public float fDown;
	Vector2 impulse;
	Rigidbody2D rb;
	public GameObject player;

	// Energy
	public int maxEnergy;
	public int rechargeAmount;
	public int rechargeFrames;
	int rechargeDelay;
	int currentEnergy;
	public Slider energySlider;
	public int fireCost;
	public int dashCost;
	int dashTimer;
	public int dashDelay;
	public int sniperCost;

	// for shooting
	public Transform blasterTip;
	public Transform blasterTip2;
	public Transform blasterTip3;
	public GameObject bullet;
	public float rateOfFire = 0.25f;
	float nextFire = 0f;

	// Check scene for ability powers
	string currentScene;

	// Use this for initialization
	void Awake () {
		energySlider.maxValue = maxEnergy;
		rb = player.GetComponent<Rigidbody2D> ();
		currentEnergy = maxEnergy;
		dashDelay *= 60;
		dashTimer = dashDelay;
		currentScene = SceneManager.GetActiveScene ().name;
	}

	// Update is called once per frame
	void Update () {
		// Update energy
		rechargeDelay--;
		if (currentEnergy < maxEnergy && rechargeDelay <= 0) {
			currentEnergy += rechargeAmount;
			rechargeDelay = rechargeFrames;
			if (currentEnergy > maxEnergy)
				currentEnergy = maxEnergy;
			//Debug.Log ("Current Energy: " + currentEnergy);
		}

		// Player Movement
		if (Input.GetKey (KeyCode.A)) {
			impulse = new Vector2 (-fLeft, 0);
			rb.AddForce (impulse);
		}

		if (Input.GetKey (KeyCode.D)) {
			impulse = new Vector2 (fRight, 0);
			rb.AddForce (impulse);
		}

		if (Input.GetKey (KeyCode.W)) {
			impulse = new Vector2 (0, fUp);
			rb.AddForce (impulse);
		}

		if (Input.GetKey (KeyCode.S)) {
			impulse = new Vector2 (0, -fDown);
			rb.AddForce (impulse);
		}

		// Player Shooting
		if (Input.GetKey (KeyCode.J) && currentEnergy >= fireCost) {
			fireRocket ();
		}

		// Player Dash
		dashTimer--;
		if (dashTimer <= 0 && Input.GetKey(KeyCode.Space) && currentEnergy >= dashCost &&
			(currentScene == "level2" || currentScene == "level2BOSS" ||
			currentScene == "level3" || currentScene == "level3BOSS")) {
			dash();
			dashTimer = dashDelay; 
		}

		// Player Sniper
		if (Input.GetKey(KeyCode.K) && currentEnergy >= sniperCost && 
			(currentScene == "level3" || currentScene == "level3BOSS")) {
			fireLaser ();
		}

		// energy slider
		energySlider.value = currentEnergy;
	}

	void fireRocket() {
		if (Time.time > nextFire) {
			nextFire = Time.time + rateOfFire;
			Instantiate(bullet, blasterTip.position, Quaternion.Euler(new Vector3(0,0,0)));
			currentEnergy -= fireCost;
		}
	}	

	void dash() {
		rb.AddForce (impulse*30);
		currentEnergy -= dashCost;
	}

	void fireLaser() {
		if (Time.time > nextFire) {
			nextFire = Time.time + rateOfFire;
			Instantiate(bullet, blasterTip.position, Quaternion.Euler(new Vector3(0,0,0)));
			Instantiate(bullet, blasterTip2.position, Quaternion.Euler(new Vector3(0,0,0)));
			Instantiate(bullet, blasterTip3.position, Quaternion.Euler(new Vector3(0,0,0)));
			currentEnergy -= sniperCost;
		}
	}
}
