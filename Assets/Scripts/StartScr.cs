using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScr : MonoBehaviour
{

     public Text beatMe; 
     
     private void Start()
     {
          beatMe.text = "Beat Me: " + PlayerPrefs.GetInt("HighScore", 0);
     }

     public void StartGame()
     {
                    
          SceneManager.LoadScene("Main");
     }
}
