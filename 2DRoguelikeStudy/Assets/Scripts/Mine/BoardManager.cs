using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Yan
{
    public class BoardManager : MonoBehaviour
    {
        public int rows;                                                                //Numbers of row in game board.
        public int columns;                                                             //Numbers of column in game board.
        private List<Vector3> gridPosition = new List<Vector3>();                       //A list of locations in Board.

        private List<Vector3> topRight = new List<Vector3>();
        private List<Vector3> topLeft = new List<Vector3>();
        private List<Vector3> botRight = new List<Vector3>();
        private List<Vector3> botLeft = new List<Vector3>();                            //Lists of possible locations to Spawn New Units. 

        public GameObject border;                                                       //Prefab for border.
        public GameObject[] floors;                                                     //Array for the Floor's Assets.
        private Transform boardHolder;
        private Transform borderHolder;
        

        //Use this to initialise gridPosition list.
        void InitialiseGridPostion()
        {
            gridPosition.Clear();

            for(int x=0;x<rows;x++)
            {
                for(int y=0;y<columns;y++)
                {
                    gridPosition.Add(new Vector3(x, y, 0f));
     
                }
            }

            //PrintTestForCollection<List<Vector3>>(gridPosition);
            
        }


        //Use this to initialise 4 list. Each is 1/4 of board.
        void InitialiseQuarterLists()
        {
            topRight.Clear();
            topLeft.Clear();
            botLeft.Clear();
            botRight.Clear();

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    if (x < rows / 2)
                    {
                        if (y < columns / 2)
                            botLeft.Add(new Vector3(x, y, 0f));
                        else
                            topLeft.Add(new Vector3(x, y, 0f));
                    }
                    else
                    {
                        if (y < columns / 2)
                            botRight.Add(new Vector3(x, y, 0f));
                        else
                            topRight.Add(new Vector3(x, y, 0f));
                    }

                }
            }

            //PrintTestForCollection<List<Vector3>>(topRight);
            //PrintTestForCollection<List<Vector3>>(topLeft);
            //PrintTestForCollection<List<Vector3>>(botLeft);
            //PrintTestForCollection<List<Vector3>>(botRight);
        }


        //Use to Print all the Content in target collection as a test.
        void PrintTestForCollection<T>(T target) where T :IEnumerable
        {
            //string name = nameof(target);
            Debug.Log("Following is the PrintTest for ");

            foreach (Vector3 v3 in target)
                Debug.Log(v3);
        }


        //Use to initialize GameBoard.
        void BoardSetUp()
        {
            boardHolder = new GameObject("boardHolder").transform;
            borderHolder = new GameObject("borderHolder").transform;
            Transform holder;

            for(int x=-1;x<=rows;x++)
            {
                for (int y = -1; y <= columns; y++)
                {
                    GameObject toInstantiate = floors[Random.Range(0, floors.Length)];
                    holder = boardHolder;

                    if (x == -1 || x == rows || y == -1 || y == columns)
                    {
                        toInstantiate = border;
                        holder = borderHolder;
                    }

                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                    instance.transform.SetParent(holder);
                }
            }
        }


        // Use this for initialization
        void Start()
        {
            InitialiseGridPostion();
            InitialiseQuarterLists();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

