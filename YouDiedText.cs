using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouDiedText : MonoBehaviour {
	public GameObject player;
	bool alive;
	// Use this for initialization
	void Awake () {
		alive = true;
//		GameObject newGO = new GameObject("myTextGO");
//		newGO.transform.SetParent(this.transform);
//
//		Text myText = newGO.AddComponent<Text>();
//		myText.text = "Ta-dah!";
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null && alive) {
			Debug.Log ("DEAD");
			transform.position = transform.parent.position + new Vector3(0, 20, 0);
			alive = false;
		}
	}
}
