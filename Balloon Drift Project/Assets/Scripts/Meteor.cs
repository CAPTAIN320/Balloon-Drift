
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	public float rotateSpeed = 200f;

	public void Start()
	{
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 20f; // Increases gravity over time
	}

	// Update is called once per frame
	void Update() 
	{
		transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

		if (transform.position.y < -10f) // Checks if object is below
		{
			Destroy(gameObject); // Deletes game object from the scene
			Debug.Log("Object Deleted");
		}
		
	}
}
