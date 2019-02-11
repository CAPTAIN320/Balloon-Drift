
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour {

	public AudioSource music;
	public AudioSource playerDeathSound;
	public Slider volume;

	void Start()
	{
		volume.value = PlayerPrefs.GetFloat("Volume", volume.value);
	}

	void Update()
	{
		music.volume = volume.value; // updates music volume to current slider value
		playerDeathSound.volume = volume.value; // updates sound to current slider vlue
	}

	public void SaveVolume()
	{
		Debug.Log ("Volume Changed");
		PlayerPrefs.SetFloat ("Volume", volume.value); // Saves volume state
	}


}
