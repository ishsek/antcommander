using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCreditsBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ButtonClicked () {
		Application.LoadLevel (8); //display credits
		Debug.Log ("Load Credits");
	}
}
