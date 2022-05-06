using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSpawning : MonoBehaviour {
	int timer;
	public ParticleSystem fireworks;
	// Use this for initialization
	void Start () {
		timer = 60 * 1;
	}
	
	// Update is called once per frame
	void Update () {
		timer--;
		if (timer <= 0) {
			Instantiate (fireworks, new Vector2 (Random.Range (-10, 10), Random.Range (-10, 10)), Quaternion.Euler (new Vector3 (0, 0, 0)));
			timer = 60 * Random.Range (1, 3);
		}
	}
}
