using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.AI;
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
        "SmallPath", "Obstacle"
    };

    public float spawnTime;
    public float spawnInterval;

    public float easyInterval;
    public float mediumInterval;
    public float hardInterval;

    public int[] intList;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < 5)
        {
            Debug.Log("Easy;");
            Easy();
        }

        if (Time.time >= 5 && Time.time < 20)
        {
            Debug.Log("Med;");
            Medium();
        }

        if (Time.time >= 20)
        {
            Debug.Log("Hard;");
            Hard();
        }
    }

    //Give random spawn points
    public void RandomPosition(int min, int max, int repetation, int interval)
    {
        MyRandom(min,max,repetation,interval);
        tempPositions = new Transform[repetation];
        for (int i = 0; i < repetation ; i++)
        {
            tempPositions[i] = spawnPositions[intList[i]];
        }
    }

    public void Easy()
    {
        spawnInterval = easyInterval;
        Debug.Log(spawnPositions.Length);
        Transform[] tempList;

        if (Time.time > spawnTime)
        {
            RandomPosition(0,spawnPositions.Length,3,0);
            for (int i = 0; i < 3; i++)
            {
            spawnPosition = tempPositions[i];
            objectPooler.SpawnFromPool(poolTagList[1], spawnPosition.position, spawnPosition.rotation);
            }
            spawnTime = Time.time + spawnInterval;
        }
    }

    public void Medium()
    {
        spawnInterval = mediumInterval;

        if (Time.time > spawnTime)
        {
            RandomPosition(1, spawnPositions.Length-2, 2, 2);
            Debug.Log("Deb : " + tempPositions[0]);
            for (int i = 0; i < 2; i++)
            {
                Debug.Log("Deb2 : " +  tempPositions[i]);

                spawnPosition = tempPositions[i];
                objectPooler.SpawnFromPool(poolTagList[Random.Range(0, 2)], spawnPosition.position, spawnPosition.rotation);
            }

            spawnTime = Time.time + spawnInterval;
        }
    }

    public void Hard()
    {
        spawnInterval = hardInterval;

        if (Time.time > spawnTime)
        {
            RandomPosition(1, spawnPositions.Length-2, 2, 2);
            for (int i = 0; i < 2; i++)
            {
                spawnPosition = tempPositions[i];
                objectPooler.SpawnFromPool(poolTagList[Random.Range(0, 2)], spawnPosition.position, spawnPosition.rotation);
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