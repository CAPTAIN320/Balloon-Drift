
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public Transform[] spawnPoints; // array of blocks
	public GameObject meteorPrefab; // gets meteor prefab

	private float timeToSpawn = 3f; // seconds after which meteors will spawn

	public float timeBetweenWaves = 1f; // sets the time between object generation

	
	private void Update()
	{

		if (Time.time >= timeToSpawn) // check if time has passed a certain number of seconds
		{
			SpawnMeteors(); // object execution
			timeToSpawn = Time.time + timeBetweenWaves; // time to spawn
			
		}
	}

	private void SpawnMeteors()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length); // creates random numbers between

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if (randomIndex == i) // checks if a position is chosen
			{
				Instantiate(meteorPrefab, spawnPoints[i].position, Quaternion.identity);
			}
		}
	}

}
