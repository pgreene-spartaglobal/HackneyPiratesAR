using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatGameController : MonoBehaviour {

	public int score = 0;

	public Text scoreText;
	public Text gameTimerText;

	public Text resultsText;

	public float gameTimer = 30f;

	// Use this for initialization
	void Start () {
		resultsText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
			if (gameTimer >= 0f) {

				scoreText.text = "Coins Collected: " + score;

				gameTimer -= Time.deltaTime;
				gameTimerText.text = "Time remaining: " + Mathf.CeilToInt (gameTimer).ToString ();



			} else {

				gameTimerText.enabled = false;
				scoreText.enabled = false;
				resultsText.text = "TIME UP\n\nYou got " + score + " Coins!";
				resultsText.enabled = true;

			}
		}

}
