
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using QAds;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;
	public GameObject settingsMenuUI;

	public AudioMixer audioMixer;

	// Update is called once per frame
	void Update()
	{
		#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Escape)) // When escape button is pressed
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
		#elif UNITY_ANDROID
		
		#endif
	}

public void Resume()
	{
		//QuickAds.instance.ShowInterstitialAd(); // Shows interstitial ad here
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f; // Turns on time
		GameIsPaused = false;
		Camera.main.GetComponent<AudioSource>().Play(); // Plays  audio source from main camera
		
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f; // Turns off time
		GameIsPaused = true;
		Camera.main.GetComponent<AudioSource>().Pause(); // Pauses  audio source from main camera
	}

	public void HomeMenu()
	{
		//QuickAds.instance.ShowInterstitialAd(); // Shows interstitial ad here
		Time.timeScale = 1f; // Turns on time
		SceneManager.LoadScene("Menu"); // Loads the Main Menu
	}

	public void SettingsMenu()
	{
		settingsMenuUI.SetActive(true); // Loads the Settings Menu
		Time.timeScale = 0f; // Turns off Time
		pauseMenuUI.SetActive(false); // Unloads the Pause Menu
	}

	public void SettingsBackButton()
	{
		settingsMenuUI.SetActive (false); // Unloads the Settings Menu
		Time.timeScale = 0f; // Turns off Time
		pauseMenuUI.SetActive(true); // Unloads the Pause Menu
	}

	public void SetVolume(float volume)
	{
		Debug.Log(volume);
		audioMixer.SetFloat ("volume", volume);
	}
		
	public void Exit()
	{
		//QuickAds.instance.ShowInterstitialAd(); // Shows interstitial ad here
		Debug.Log("Quit"); // Displays Quit in the console
		Application.Quit(); // Ends the application
	}
}
