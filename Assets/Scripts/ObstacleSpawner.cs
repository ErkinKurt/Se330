using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObstacleSpawner : MonoBehaviour
{
    public ObjectPooler objectPooler;

    public Transform[] spawnPositions;

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

    // Update is called once per frame
    void Update()
    {
       SpawnObstacles();
    }

    //Give random spawn points
    public void RandomPosition(int min, int max, int repetation, int interval)
    {
        MyRandom(min, max, repetation, interval);
        tempPositions = new Transform[repetation];
        for (int i = 0; i < repetation; i++)
        {
            tempPositions[i] = spawnPositions[intList[i]];
        }
    }

   
    public void SpawnObstacles()
    {
        Debug.Log(spawnPositions.Length);

        if (Time.time > spawnTime)
        {
            int a = spawnPositions.Length;
            if (Random.RandomRange(0, 10) == 1)
            {
                a = Random.RandomRange(2,4);
            }
            int temp = Random.RandomRange(0, 6);
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                spawnPosition = spawnPositions[i];
                if (i == temp || i == a)
                {
                    GameObject coin = objectPooler.SpawnFromPool(poolTagList[1], spawnPosition.position, spawnPosition.rotation);
                    coin.GetComponent<ObstacleMove>().speed = obstacleSpeed;
                    continue;
                }
                
                GameObject o = objectPooler.SpawnFromPool(poolTagList[0], spawnPosition.position, spawnPosition.rotation);
                o.GetComponent<ObstacleMove>().speed = obstacleSpeed;
            }

            spawnTime = Time.time + spawnInterval;
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
                Debug.Log("kasdosakd");
                MyRandom(min, max, repetation, interval);
            }
        }

        intList = tempArray;
    }
}