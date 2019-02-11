
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using QAds;

public class MainMenu : MonoBehaviour {

	public GameObject creditsMenu;

	public void Start()
	{
		QuickAds.instance.ShowInterstitialAd(); // Show interstitial ad here
		QuickAds.instance.ShowBanner();
	}

	public void StartGame()
	{
		Time.timeScale = 1f; // Turns on time
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the next scene
	}

	public void Credits()
	{
		creditsMenu.SetActive(true);
	}

	public void CreditsBackButton()
	{
		creditsMenu.SetActive(false);
	}
}
