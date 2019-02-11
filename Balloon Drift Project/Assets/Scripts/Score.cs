using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	public Text scoreText;
	public Text highScore;

	int score;

	void Update()
	{
		highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); // Outputs highscore to string
		if (score > PlayerPrefs.GetInt("HighScore", 0)) // Checks if score is greater than current highscore
		{
			Debug.Log ("Highscore Achieved");
			PlayerPrefs.SetInt("HighScore", score); // Keeps Highscore
			highScore.text = score.ToString(); // Converts the score to text`
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		

		if (col.tag == "Meteor") // Checks if condition is true
		{

			score++;
			Debug.Log("Your have scored a point");
			scoreText.text = score.ToString(); // Outputs gameplay score to a string

		}	


	}

	public void ResetHighscore()
	{
		PlayerPrefs.DeleteKey("HighScore");
		highScore.text = "0"; // Makes seeing the reset in realtime
	}

}
