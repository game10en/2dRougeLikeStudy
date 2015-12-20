﻿using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximun;

        public Count(int min, int max)
        {
            minimum = min;
            maximun = max;
        }
    }

    public int columns = 8;
    public int rows = 8;

    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);

    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;

    private Transform boardHolder; //make hierarchy clean
    private List<Vector3> gridPositions = new List<Vector3>();

	void InitialiseList()
	{
		gridPositions.Clear ();

		for(int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
	}

    void BoardSetup()
    {
        boardHolder = new GameObject("BoardHolder").transform;

        for(int x = -1; x < columns + 1; x++)
        {
            for(int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPostion = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPostion;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximunm)
    {
        int objectCount = Random.Range(minimum, maximunm + 1);

        for (int i= 1; i < objectCount + 1; i++)
        {
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Vector3 randomPosition = RandomPosition();

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }

    }

    public void SetupScreen(int level)
    {
        BoardSetup();

        InitialiseList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximun);
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximun);
        int enemyCount = (int)Mathf.Log(level, 2f);
        LayoutObjectAtRandom(enemyTiles,enemyCount,enemyCount);

        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
