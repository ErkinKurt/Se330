 using System.Collections;
using System.Collections.Generic;
 using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject gameOverUI;
	public ObstacleSpawner obstacleSpawner;

	public bool gameFinished = false;
	public int score = 0;
	public float difficulty;
	public float obstacleSpeedRatio;
	public float obstacleSpawnSpeedRatio;

	// Update is called once per frame
	void Update () {
		if (gameFinished)
		{
			Debug.Log("GameOverUI");
			gameOverUI.SetActive(true);
			gameFinished = false;
		}

		if (Time.time > difficulty)
		{
			obstacleSpawner.obstacleSpeed *= obstacleSpeedRatio;
			obstacleSpawner.spawnInterval *= obstacleSpawnSpeedRatio;
			difficulty += 15;
		}
		
	}

	public void RestartLevel()
	{
		gameOverUI.SetActive(false);
		SceneManager.LoadScene("Main");
	}
}
