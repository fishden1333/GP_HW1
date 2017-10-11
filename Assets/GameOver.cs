using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	bool showGUI = false;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Character")
		{
			showGUI = true;
		}
	}

	// Show the text if the player get to the end
	void OnGUI()
	{
		if (showGUI)
		{
			GUI.Label(new Rect(10, 10, 300, 50), "Congratulations!\nYou finished the game!");
		}
  }
}
