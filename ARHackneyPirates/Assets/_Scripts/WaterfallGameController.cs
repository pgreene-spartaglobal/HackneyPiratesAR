using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class WaterfallGameController : MonoBehaviour {

	public int score = 0;

	public GameObject leftNet;
	public GameObject rightNet;

	public GameObject leftNetButton;
	public GameObject rightNetButton;

	public GameObject coinPrefab;
	public GameObject coinSpawn1;
	public GameObject coinSpawn2;

	public Transform imageTarget;

	public Text scoreText;
	public Text gameTimerText;

	public Text resultsText;

	private float spawnTimer;

	public float gameTimer = 30f;

	public static bool isWaterfall = false;


	// Use this for initialization
	void Start () {
		leftNet.SetActive (false);
		rightNet.SetActive (false);
		resultsText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isWaterfall) {
			if (gameTimer >= 0f) {

				scoreText.text = "Coins Collected: " + score;

				gameTimer -= Time.deltaTime;
				gameTimerText.text = "Time remaining: " + Mathf.CeilToInt (gameTimer).ToString ();

				spawnTimer += Time.deltaTime;


				if (spawnTimer >= 1f && gameTimer >= 2f) {
					spawnTimer = 0f;

					int randomNumber = Random.Range (1, 3);
					if (randomNumber == 1) {
						GameObject coin = Instantiate (coinPrefab, coinSpawn1.transform.position, coinPrefab.transform.rotation, imageTarget) as GameObject;
						//coin.transform.localScale /= 5f;
						//Destroy (coin, 7f);
					} else if (randomNumber == 2) {
						GameObject coin = Instantiate (coinPrefab, coinSpawn2.transform.position, coinPrefab.transform.rotation, imageTarget) as GameObject;
						//coin.transform.localScale /= 5f;
						//Destroy (coin, 7f);
					}
				}
			} else {
				leftNet.SetActive (false);
				rightNet.SetActive (false);

				leftNetButton.SetActive (false);
				rightNetButton.SetActive (false);

				gameTimerText.enabled = false;
				scoreText.enabled = false;
				resultsText.text = "TIME UP\n\nYou got " + score + " Coins!";
				resultsText.enabled = true;

			}
		}

	}

	public void LeftNet()
	{
		leftNet.SetActive (true);
		rightNet.SetActive (false);
	}

	public void RightNet()
	{
		leftNet.SetActive (false);
		rightNet.SetActive (true);
	}
}
