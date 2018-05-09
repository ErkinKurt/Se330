using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObstacleSpawner : MonoBehaviour
{
    public ObjectPooler objectPooler;

    public Transform[] spawnPositionsEasy;

    public Transform[] spawnPositionsHard;

    private Transform spawnPosition;

    private int[] tempArray;
    private Transform[] tempPositions;
    private GameObject[] _gameObjects;
    
    
    private string[] poolTagList =
    {
        "LineObstacle", "Coin"
    };

    public float spawnTime;
    public float spawnInterval;

    public float obstacleSpeed;
    
    public int[] intList;

   

   
    public void SpawnObstacles(Transform []spawnPositions, string obstacleTag)
    {
        Debug.Log(spawnPositions.Length);

        if (Time.time > spawnTime)
        {
            //Initialize secondRandomSpawnPoint... 
            int secondRandomSpawnPoint = spawnPositions.Length;
            if (Random.RandomRange(0, 10) == 1)
            {
                secondRandomSpawnPoint = Random.RandomRange(2,4);
            }
            int temp = Random.RandomRange(0, 4);
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                spawnPosition = spawnPositions[i];
                if (i == temp || i == secondRandomSpawnPoint)
                {
                    //Coin.y -1 ---> Coin portal
                    GameObject coin = objectPooler.SpawnFromPool(poolTagList[1], new Vector3(spawnPosition.position.x,spawnPosition.position.y - 1,spawnPosition.position.z), spawnPosition.rotation);
                    coin.GetComponent<ObstacleMove>().speed = obstacleSpeed;
                    if (obstacleTag == "HardLineObstacle")
                    {
                        coin.transform.localScale = new Vector3(0.18f,0.4f);
                    }
                    
                    continue;
                }
                
                GameObject o = objectPooler.SpawnFromPool(obstacleTag, spawnPosition.position, spawnPosition.rotation);
                o.GetComponent<ObstacleMove>().speed = obstacleSpeed;
            }

            spawnTime = Time.time + spawnInterval;
        }
    }
    
    //Give random spawn points
    public void RandomPosition(int min, int max, int repetation, int interval)
    {
        MyRandom(min, max, repetation, interval);
        tempPositions = new Transform[repetation];
        for (int i = 0; i < repetation; i++)
        {
            tempPositions[i] = spawnPositionsEasy[intList[i]];
        }
    }


    public void MyRandom(int min, int max, int repetation, int interval)
    {
        tempArray = new int[repetation];

        for (int i = 0; i < repetation; i++)
        {
            tempArray[i] = Random.Range(min, max);
        }

        Array.Sort(tempArray);


        for (int j = 1; j < repetation; j++)
        {
            if ((int) Mathf.Abs(tempArray[j] - tempArray[j - 1]) <= interval)
            {
                MyRandom(min, max, repetation, interval);
            }
        }

        intList = tempArray;
    }
}