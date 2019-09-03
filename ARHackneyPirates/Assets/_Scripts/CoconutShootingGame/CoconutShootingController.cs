using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoconutShootingController : MonoBehaviour 
{
    public int score = 0;
    public int targetScoreValue = 1;
    public GameObject startPanel;
    public Text scoreText;
    public Text gameTimerText;
    public Text resultsText;
    public float gameTimer = 30f;
    public int numberOfTargets = 5;
    public Transform[] spawnPoints;
    public List<Target> targets = new List<Target>();
    public bool gameInProgress = false;
    public GameObject targetPrefab;
    public Shoot shooter;

    private void Start() 
    {
        shooter.enabled = false;
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
        shooter.enabled = true;
        startPanel.SetActive(false);
        SpawnTargets();
    }

    public void EndGame()
    {
        gameInProgress = false;
        shooter.enabled = false;
        gameTimerText.enabled = false;
        scoreText.enabled = false;
        resultsText.text = "TIME UP\n\nYou destroyed " + score + " targets!";
        resultsText.enabled = true;
    }

    private void SpawnTargets()
    {
        List<int> randomIntList = new List<int>();

        for (int i = 0; i < numberOfTargets; i++)
        {
            int randomNumber = Random.Range(0, spawnPoints.Length);

            while (randomIntList.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, spawnPoints.Length);
            }

            randomIntList.Add(randomNumber);

            GameObject targetObject = Instantiate(targetPrefab, transform.parent);
            targetObject.transform.position = spawnPoints[randomNumber].position;
            targetObject.GetComponent<Target>().moveSpeed = Random.Range(-2, 2);
            targets.Add(targetObject.GetComponent<Target>());
        }
    }

    public void RemoveTarget(Target targetToDestroy)
    {
        IncreaseScore(targetScoreValue);
        targets.Remove(targetToDestroy);

        // Spawn a new set of targets once the current set has been destroyed
        if (targets.Count == 0)
        {
            SpawnTargets();
        }
    }

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = "Targets destroyed: " + score;
    }
}
