using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBOSS3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonClicked () {
		Application.LoadLevel (6); //load level 3
		Debug.Log ("Load Lvl3 BOSS");
	}
}
