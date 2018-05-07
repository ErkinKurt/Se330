 using System.Collections;
using System.Collections.Generic;
 using UnityEngine.SceneManagement;
using UnityEngine;
 using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject gameOverUI;

	public bool gameFinished = false;
	public int score = 0;
	public GameObject _textGO;
	private Text _text;

	private void Start()
	{
		_text = _textGO.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (gameFinished)
		{
			Debug.Log("GameOverUI");
			gameOverUI.SetActive(true);
			//gameFinished = false;
			//_textGO.SetActive(false);
		}
		else
		{
			_text.GetComponent<Text>().text = "Score: " + score;
		}
	}

	public void RestartLevel()
	{
		gameOverUI.SetActive(false);
		SceneManager.LoadScene("Main");
	}
}
