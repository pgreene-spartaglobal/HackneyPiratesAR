using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinGameController : MonoBehaviour 
{
    public int score = 0;
    public GameObject startPanel;
    public Text scoreText;
    public Text gameTimerText;
    public Text resultsText;
    public float gameTimer = 30f;
    public int numberOfCoins = 5;
    public bool gameInProgress = false;
    public GameObject coinPrefab;
    public Penguin penguinMovement;

    public Terrain terrain;

    private void Start() 
    {
        penguinMovement.enabled = false;
        resultsText.enabled = false;
    }

    private void Update() 
    {
        if (gameTimer >= 0f && gameInProgress) 
        {           
            gameTimer -= Time.deltaTime;
            gameTimerText.text = "Time remaining: " + Mathf.CeilToInt (gameTimer).ToString ();
        } 
        else if (gameTimer < 0f && gameInProgress) 
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        gameInProgress = true;
        penguinMovement.enabled = true;
        startPanel.SetActive(false);

        for (int i = 0; i < numberOfCoins; i++)
        {
            SpawnCoin();
        }
    }

    public void EndGame()
    {
        gameInProgress = false;
        penguinMovement.enabled = false;
        gameTimerText.enabled = false;
        scoreText.enabled = false;
        resultsText.text = "TIME UP\n\nYou got " + score + " Coins!";
        resultsText.enabled = true;
    }

    public void SpawnCoin()
    {
        float posX = Random.Range(terrain.transform.position.x, terrain.transform.position.x + terrain.terrainData.size.x);
        float posZ = Random.Range(terrain.transform.position.z, terrain.transform.position.z + terrain.terrainData.size.z);
        float posY = terrain.SampleHeight(new Vector3(posX, 0, posZ));
        Vector3 spawnPosition = new Vector3(posX, posY, posZ);

        GameObject coinObject = Instantiate(coinPrefab);
        coinObject.transform.position = spawnPosition;
        coinObject.GetComponent<Rigidbody>().useGravity = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Coins Collected: " + score;
    }	
}
