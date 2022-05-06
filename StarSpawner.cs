using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {
	int spawnTimeDelay;
	int spawnTimer;
	public GameObject star;

	// Use this for initialization
	void Start () {
		spawnTimeDelay = Random.Range (100, 300);
		spawnTimer = spawnTimeDelay;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer--;
		if (spawnTimer <= 0) {
			Instantiate (star, new Vector2 (Random.Range (-10, 10), 9), Quaternion.Euler (new Vector3 (0, 0, 0)));
			spawnTimeDelay = Random.Range (500, 700);
			spawnTimer = spawnTimeDelay;
		}
	}
}
