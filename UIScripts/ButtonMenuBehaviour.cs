using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenuBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonClicked () {
		Application.LoadLevel (0); //return to menu
		Debug.Log ("Load Menu");
	}
}
