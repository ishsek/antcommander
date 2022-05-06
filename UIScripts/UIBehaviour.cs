using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour {
	float fuelBar;
	float healthBar;
	Vector2 posFuel = new Vector2((5.0f / 100) * Screen.width,(5.0f / 100) * Screen.height);
	Vector2 sizeFuel = new Vector2((15.0f / 100) * Screen.width,(4.0f / 100) * Screen.height);
	Vector2 posHealth = new Vector2((80.0f / 100) * Screen.width,(5.0f / 100) * Screen.height);
	Vector2 sizeHealth = new Vector2((15.0f / 100) * Screen.width,(4.0f / 100) * Screen.height);
	Texture2D emptyTexFuel;
	Texture2D fullTexFuel;
	Texture2D emptyTexHealth;
	Texture2D fullTexHealth;

	// Use this for initialization
	void Start () {
		fuelBar = sizeFuel.x;
		healthBar = sizeHealth.x;
	}

	//code obtained from: http://answers.unity3d.com/questions/11892/how-would-you-make-an-energy-bar-loading-progress.html
	void OnGUI() {
		//draw the background:
		GUI.BeginGroup(new Rect(posFuel.x, posFuel.y, sizeFuel.x, sizeFuel.y));
		GUI.Box(new Rect(0,0, sizeFuel.x, sizeFuel.y), emptyTexFuel);
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, sizeFuel.x * fuelBar, sizeFuel.y));
		GUI.Box(new Rect(0,0, sizeFuel.x, sizeFuel.y), fullTexFuel);
		GUI.EndGroup();
		GUI.EndGroup();

		//draw the background:
		GUI.BeginGroup(new Rect(posHealth.x, posHealth.y, sizeHealth.x, sizeHealth.y));
		GUI.Box(new Rect(0,0, sizeHealth.x, sizeHealth.y), emptyTexHealth);
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, sizeHealth.x * healthBar, sizeHealth.y));
		GUI.Box(new Rect(0,0, sizeHealth.x, sizeHealth.y), fullTexHealth);
		GUI.EndGroup();
		GUI.EndGroup();
	}
	
	// Update is called once per frame
	void Update () {
		//fuelBar -= modify fuel bar
		//healthBar -= modify boss health bar
	}
}
