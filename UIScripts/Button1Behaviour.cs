using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button1Behaviour : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonClicked () {
		Application.LoadLevel (1); //load level 1
		Debug.Log ("Load Lvl2");
	}
}
