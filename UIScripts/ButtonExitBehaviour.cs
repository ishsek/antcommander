using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExitBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ButtonClicked () {
		Application.Quit (); //exit the application
	}
}
