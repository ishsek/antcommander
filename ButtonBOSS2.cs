using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBOSS2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonClicked () {
		Application.LoadLevel (4); //load level 1
		Debug.Log ("Load BOSS2");
	}
}
