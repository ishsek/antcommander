using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	// To track enemy spawning
	public Slider enemiesRemainingSlider;
	public int enemyTotal;
	public int enemy1AtATime;
	int enemiesDestroyed;
	int enemiesSpawned;
	public int spawnTimer;
	int spawnCountdown;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject boss1;
	public GameObject boss2;
	public GameObject boss3;
	int nextLevelTimer;
	// Count enemies active
	private GameObject[] getCount;
	int enemyCount;

	// To know which level we're on
	// src: https://docs.unity3d.com/540/Documentation/ScriptReference/SceneManagement.SceneManager.GetActiveScene.html
	string currentScene;

	// Use this for initialization
	void Start () {
		if (enemiesRemainingSlider != null) {
			enemiesRemainingSlider.maxValue = enemyTotal;
		}
		nextLevelTimer = 60 * 3;
		spawnCountdown = spawnTimer;
		currentScene = SceneManager.GetActiveScene ().name;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentScene == "level1") {
			level1Spawning ();
			updateEnemies ();
		} else if (currentScene == "level1BOSS") {
			level1BOSSSpawning ();
		} else if (currentScene == "level2") {
			level2Spawning ();
			updateEnemies ();
		} else if (currentScene == "level2BOSS") {
			level2BOSSSpawning ();
		} else if (currentScene == "level3") {
			level3Spawning ();
			updateEnemies ();
		} else if (currentScene == "level3BOSS") {
			level3BOSSpawning ();
		}
	}

	void updateEnemies() {
		enemiesRemainingSlider.value = enemyTotal - enemiesDestroyed;
	}

	// Level 1 spawner
	void level1Spawning() {
		if (GameObject.FindGameObjectsWithTag ("Enemy") != null) {
			getCount = GameObject.FindGameObjectsWithTag ("Enemy");
			enemyCount = getCount.Length;
			if (enemyCount < enemy1AtATime)
				spawnCountdown--;
			if (spawnCountdown <= 0 && enemyCount < enemy1AtATime && enemiesSpawned < enemyTotal) {
				Instantiate (enemy1, new Vector2 (Random.Range (-7, 7), Random.Range (3, 7)), Quaternion.Euler (new Vector3 (0, 0, 0)));
				enemiesSpawned++;
				spawnCountdown = spawnTimer;
				enemyCount++;
				Debug.Log ("enemy count: " + enemyCount);
				Debug.Log ("destroyed count: " + enemiesDestroyed);
			}
		}

		if (enemiesDestroyed == enemyTotal)
			Application.LoadLevel (2);
	}

	void level1BOSSSpawning() {
		if (boss1 == null) {
			Debug.Log ("Boss Destroyed");
			nextLevelTimer--;
			if (nextLevelTimer <= 0) {
				Application.LoadLevel (3);
			}
		}
	}

	// level 2 spawner
	void level2Spawning() {
		if (GameObject.FindGameObjectsWithTag ("Enemy") != null) {
			getCount = GameObject.FindGameObjectsWithTag ("Enemy");
			enemyCount = getCount.Length;
			if (enemyCount < enemy1AtATime)
				spawnCountdown--;
			if (spawnCountdown <= 0 && enemyCount < enemy1AtATime && enemiesSpawned < enemyTotal) {
				if (Random.Range (0, 10) < 4) {
					Instantiate (enemy1, new Vector2 (Random.Range (-7, 7), Random.Range (3, 7)), Quaternion.Euler (new Vector3 (0, 0, 0)));
				} else {
					Instantiate (enemy2, new Vector2 (Random.Range (-7, 7), Random.Range (9, 10)), Quaternion.Euler (new Vector3 (0, 0, 0)));
				}
				enemiesSpawned++;
				spawnCountdown = spawnTimer;
				enemyCount++;
				Debug.Log ("enemy count: " + enemyCount);
			}
		}

		if (enemiesDestroyed == enemyTotal)
			Application.LoadLevel (4);
	}

	void level2BOSSSpawning() {
		if (boss2 == null) {
			nextLevelTimer--;
			if (nextLevelTimer <= 0) {
				Application.LoadLevel (5);
			}
		}
	}

	// Level 3 spawner
	void level3Spawning() {
		if (GameObject.FindGameObjectsWithTag ("Enemy") != null) {
			getCount = GameObject.FindGameObjectsWithTag ("Enemy");
			enemyCount = getCount.Length;
			if (enemyCount < enemy1AtATime)
				spawnCountdown--;
			if (spawnCountdown <= 0 && enemyCount < enemy1AtATime && enemiesSpawned < enemyTotal) {
				int spawnRNG = Random.Range (0, 10);
				if (spawnRNG < 2) {
					Instantiate (enemy1, new Vector2 (Random.Range (-7, 7), Random.Range (3, 7)), Quaternion.Euler (new Vector3 (0, 0, 0)));
				} else if (spawnRNG >= 2 && spawnRNG < 6) {
					Instantiate (enemy2, new Vector2 (Random.Range (-7, 7), Random.Range (9, 10)), Quaternion.Euler (new Vector3 (0, 0, 0)));
				} else {
					Instantiate (enemy3, new Vector2 (Random.Range (-7, 7), Random.Range (9, 10)), Quaternion.Euler (new Vector3 (0, 0, 0)));
				}
				enemiesSpawned++;
				spawnCountdown = spawnTimer;
				enemyCount++;
				Debug.Log ("enemy count: " + enemyCount);
			}
		}

		if (enemiesDestroyed == enemyTotal)
			Application.LoadLevel (6);
	}

	void level3BOSSpawning() {
		if (boss3 == null) {
			nextLevelTimer--;
			if (nextLevelTimer <= 0) {
				Application.LoadLevel (7);
			}
		}
	}

	// Add to destroyed count, called from enemyHealth
	public void addDestroyedCount() {
		enemiesDestroyed++;
		Debug.Log ("destroyed count: " + enemiesDestroyed);
	}
}
