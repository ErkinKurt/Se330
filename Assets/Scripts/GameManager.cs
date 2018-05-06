 using System.Collections;
using System.Collections.Generic;
 using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject gameOverUI;

	public bool gameFinished = false;
	public int score = 0;


	// Update is called once per frame
	void Update () {
		if (gameFinished)
		{
			Debug.Log("GameOverUI");
			gameOverUI.SetActive(true);
			gameFinished = false;
		}

		//Debug.Log("Score: " + score);
	}

	public void RestartLevel()
	{
		gameOverUI.SetActive(false);
		SceneManager.LoadScene("Main");
	}
}
