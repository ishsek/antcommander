using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ButtonClicked () {
		Application.LoadLevel (5); //load level 3
		Debug.Log ("Load Lvl3");
	}
}
