using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ObstacleSpawner : MonoBehaviour
{
    public ObjectPooler objectPooler;

    public Transform[] spawnPositions;

    private Transform spawnPosition;

    private GameObject[] _gameObjects;

    private string[] poolTagList =
    {
        "Lol", "Cube"
    };

    public float spawnTime;
    public float spawnInterval;

    public float easyInterval;
    public float mediumInterval;
    public float hardInterval;


    // Update is called once per frame
    void Update()
    {
        if (Time.time < 5)
        {
            Easy();
        }
        if (Time.time >= 5 && Time.time < 20)
        {
            Medium();
        }

        if (Time.time >= 20)
        {
            Hard();    
        }
    }

    //Give random spawn points
    public void RandomPosition()
    {
        spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length - 1)];
    }

    public void Easy()
    {
        spawnInterval = easyInterval;
        
        if (Time.time > spawnTime)
        {
            RandomPosition();
            objectPooler.SpawnFromPool(poolTagList[0], spawnPosition.position, spawnPosition.rotation);
            spawnTime = Time.time + spawnInterval;
        }
    }
    
    public void Medium()
    {
        spawnInterval = mediumInterval;
        
        if (Time.time > spawnTime)
        {
            RandomPosition();
            objectPooler.SpawnFromPool(poolTagList[Random.Range(0, 2)], spawnPosition.position, spawnPosition.rotation);
            spawnTime = Time.time + spawnInterval;
        }
    }
    
    public void Hard()
    {
        spawnInterval = hardInterval;
        
        if (Time.time > spawnTime)
        {
            RandomPosition();
            objectPooler.SpawnFromPool(poolTagList[Random.Range(0, 2)], spawnPosition.position, spawnPosition.rotation);
            spawnTime = Time.time + spawnInterval;
        }
    }
    
    
}