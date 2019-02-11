
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D skyCollider; //This stores a reference to the collider attached to the Sky.
	private float skyVerticalLength; //A float to store the x-axis length of the collider2D attached to the Sky GameObject.


	// Use this for initialization
	void Start() 
	{
		// Get and store a reference to the collider2D attached to Sky.
		skyCollider = GetComponent<BoxCollider2D>();
		//Store the size of the collider along the y axis (its length in units).
		skyVerticalLength = skyCollider.size.y;
	}
	
	// Update is called once per frame
	void Update() 
	{
		//Check if the difference along the y axis between the main Camera and the position of the object this is attached to is greater than skyVerticalLength.
		if (transform.position.y < -skyVerticalLength)
		{
			//If true, this means this object is no longer visible and we can safely move it upward to be re-used.
			RepositionBackground();
		}
	}

	//Moves the object this script is attached to up in order to create our looping background effect.
	private void RepositionBackground()
	{
		//This is how far up we will move our background object, in this case, twice its length. This will position it directly up of the currently visible background object.
		Vector2 skyOffset = new Vector2(0, (skyVerticalLength) * 2f);
		//Move this object from it's position offscreen, below the player, to the new position off-camera upwards of the player.
		transform.position = (Vector2)transform.position + skyOffset;
	}
}
