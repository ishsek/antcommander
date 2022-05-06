using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBOSS1Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonClicked () {
		Application.LoadLevel (2); //load level 1
		Debug.Log ("Load BOSS 2");
	}
}
