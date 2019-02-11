
/*
* Copyright (c) Yaqub Mahmoud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using QAds;

public class GameManager : MonoBehaviour {

	public float slowness = 10f;
	public Animator animator;
	public GameObject restartMenuUI;
	public AudioSource backgroundAudio;

	public void EndGame() // Ends the Game
	{
		animator.SetTrigger("EndGame");
		StartCoroutine(RestartLevel());
		
	}

	public IEnumerator RestartLevel() // Restarts the level and slows down time in the process
	{

		Time.timeScale = 1f / slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

		yield return new WaitForSeconds(1f / slowness);

		Time.timeScale = 1f; // Turns time back on
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
		yield return new WaitForSecondsRealtime(0);

		//QuickAds.instance.ShowInterstitialAd(); // Show interstitial ad here

		RestartMenu(); // Loads the Restart Menu UI

	}

	public void RestartMenu()
	{
		restartMenuUI.SetActive(true);
		Time.timeScale = 0f; // Turns off Time
		backgroundAudio.mute = !backgroundAudio.mute; // Stops background audio from playing
	}

	public void RestartButton()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the scene
		Time.timeScale = 1f; // Turns Time back on
	}

}
