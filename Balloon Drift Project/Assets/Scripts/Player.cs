
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QAds;

public class Player : MonoBehaviour {

	public float speed = 20f;
	public float mapWidth = 5f;
	public float mapHeight = 5f;
	public Rigidbody2D rbPlayer;
	public GameObject playerExplosion;
	public GameObject playerDeath;

	private void Start()
	{
		rbPlayer = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{

		/*//Moves Forward and back along z axis
		rbPlayer.transform.Translate(Vector2.up * Time.fixedDeltaTime * Input.GetAxis("Vertical") * speed);
		//Moves Left and right along x Axis
		rbPlayer.transform.Translate(Vector2.right * Time.fixedDeltaTime * Input.GetAxis("Horizontal") * speed);*/

		HorizontalMovement();

	}

	private void Update()
	{
		BoundGameObjectToScreen();
	}

	void HorizontalMovement() // Makes object move left and right using keyboard
	{
		float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed; // Get user input
		
		Vector2 newXPosition = rbPlayer.position + Vector2.right * x; // Record player position

		newXPosition.x = Mathf.Clamp(newXPosition.x, -mapWidth, mapWidth); // Set player position

		rbPlayer.MovePosition(newXPosition); // Update player position
	}

	void VerticalMovement()
	{
		float y = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

		Vector2 newYPosition = rbPlayer.position + Vector2.up * y;

		newYPosition.y = Mathf.Clamp(newYPosition.y, -mapHeight, mapHeight);

		rbPlayer.MovePosition(newYPosition);
	}
	
	void BoundGameObjectToScreen() // makes the game object stay within the gameview screen regardless of touch or keyboard input
	{
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		if (tag == "Player") // Checks if a the player is hit
		{
			Debug.Log("You have been hit");
			Instantiate(playerExplosion, transform.position, transform.rotation); // renders explosion particle into scene on the player
			playerDeath.SetActive(true);
			Destroy(gameObject); // removes the player from the scene
		}

		
		FindObjectOfType<GameManager>().EndGame(); // Ends the game

	}

}
