using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathless : MonoBehaviour
{

	public int highScore;
	private static bool created = false;

	void Awake()
	{
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
			Debug.Log("Awake: " + this.gameObject);
		}
	}

	public void UpdateHighScore(int hScore)
	{
		highScore = hScore;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
