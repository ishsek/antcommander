using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ButtonClicked () {
		Application.LoadLevel (3); //load level 2
		Debug.Log ("Load Lvl2");
	}
}
