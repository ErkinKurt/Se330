 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine.SceneManagement;
 using UnityEngine;
 using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject gameOverUI;
	public ObstacleSpawner obstacleSpawner;

	public bool gameFinished = false;
	public int score = 0;
	public GameObject currentScoreText;
	public GameObject endGameScoreText;
	public GameObject highScoreText;
	public int highScore;
	public float difficultyTimeInterval;
	public string tempObstacleTag;
	public Transform[] tempSpawnPositions;
	public float obstacleSpeedCoefficient;
	// obstacleSpawnSpeedCoefficient -> [0-1]
	public float obstacleSpawnSpeedCoefficient;

	private void Start()
	{

		highScore = PlayerPrefs.GetInt("HighScore", 0);
		tempSpawnPositions = obstacleSpawner.spawnPositionsEasy;
		tempObstacleTag = "LineObstacle";
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.Log("Debug :: " + tempObstacleTag);
		if (gameFinished)
		{
			Debug.Log("highscore" + highScore);
			gameOverUI.SetActive(true);
			if (score >= highScore)
			{
				endGameScoreText.SetActive(false);
				highScoreText.GetComponent<Text>().text = "New High \nScore: " + score;
				PlayerPrefs.SetInt("HighScore",score);
				currentScoreText.SetActive(false);
				highScoreText.SetActive(true);
			}
			else
			{
				endGameScoreText.GetComponent<Text>().text = "Score: " + score;
				currentScoreText.SetActive(false);
				endGameScoreText.SetActive(true);
			}
		}
		else
		{
		obstacleSpawner.SpawnObstacles(tempSpawnPositions,tempObstacleTag);
		
		Debug.Log("Spawn Interval APDATE"+obstacleSpawner.spawnInterval);
		
		if (obstacleSpawner.spawnInterval > 1.3f && Time.time > difficultyTimeInterval )
		{
			obstacleSpawner.obstacleSpeed *= obstacleSpeedCoefficient;
			obstacleSpawner.spawnInterval *= obstacleSpawnSpeedCoefficient;
			difficultyTimeInterval = Time.time + 15;
		}
		else if(obstacleSpawner.spawnInterval <= 1.3f)
		{
			Debug.Log("HARD");
			tempSpawnPositions = obstacleSpawner.spawnPositionsHard;
			tempObstacleTag = "HardLineObstacle";
		}
			currentScoreText.GetComponent<Text>().text= "Score: " + score;
		}
		
		
		
	}

	public void RestartLevel()
	{
		gameOverUI.SetActive(false);
		SceneManager.LoadScene("Main");
	}
}
