using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoudManager2 : MonoBehaviour
{
    [Header("Array trucks")]
    public List<GameObject> blocks;
    public GameObject roadPref;

    [Header("Player")]
    public GameObject player;
    

    [Header("Car prefabs")]
    public GameObject carPrefab1;
    public GameObject carPrefab2;
    public GameObject carPrefab3;
    public GameObject carPrefab4;

    //For instaniate GameObject
    [Header("Time of car creating")]
    private System.Random rand = new System.Random();
    public float timeToCar;
    public float plusTimeAdd;
    private GameObject switchPref;
    private GameObject lastPref;
    private float xPosCarPref;
    private float lastXPosCarPref;
    public float zPosCarPref;
    private float lastZPosCarPref;


    private float z;

    private void Start()
    {
        lastPref = carPrefab1;
        switchPref = carPrefab1;

        xPosCarPref = 0f;
        lastXPosCarPref = 0f;

        zPosCarPref = 500f;
        lastZPosCarPref = 0f;
    }
    private void Update()
    {
        //Spawn if road
        if (!Move.isLive)
        {
            return;
        }
        z = player.GetComponent<Move>().nowPos.z;

        var last1 = blocks[blocks.Count - 1];
        
        if(z > last1.transform.position.z - 1000f)
        {
            GameObject block = Instantiate(roadPref, new Vector3(last1.transform.position.x, last1.transform.position.y, last1.transform.position.z + 353), Quaternion.identity);
            blocks.Add(block);
        }
        foreach(GameObject blocke in blocks)
        {
            bool fetched = blocke.GetComponent<RoudBlock>().Fetch(z);
            if (fetched)
            {
                blocks.Remove(blocke);
                blocke.GetComponent<RoudBlock>().Delete();
                break;
            }
        }
        
        //Spawn of cars
        var Xlast = blocks[blocks.Count - 2];
        if (Time.time > timeToCar)
        {
            while (switchPref == lastPref)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        switchPref = carPrefab1;
                        break;
                    case 2:
                        switchPref = carPrefab2;
                        break;
                    case 3:
                        switchPref = carPrefab3;
                        break;
                    case 4:
                        switchPref = carPrefab4;
                        break;
                }

        }
            while (xPosCarPref == lastXPosCarPref)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        xPosCarPref = -6f;
                        break;
                    case 2:
                        xPosCarPref = -2f;
                        break;
                    case 3:
                        xPosCarPref = 2f;
                        break;
                    case 4:
                        xPosCarPref = 6f;
                        break;
                }
            }
            while (zPosCarPref == lastZPosCarPref)
            {
                switch (rand.Next(1, 5))
                {
                    case 1:
                        zPosCarPref = 40f;
                        break;
                    case 2:
                        zPosCarPref = 25f;
                        break;
                    case 3:
                        zPosCarPref = 15f;
                        break;
                    case 4:
                        zPosCarPref = 0f;
                        break;
                }
            }

            lastPref = switchPref;
            lastXPosCarPref = xPosCarPref;
            lastZPosCarPref = zPosCarPref;

            Instantiate(switchPref, new Vector3(xPosCarPref, Xlast.transform.position.y + 1.08f, z + 1000f + zPosCarPref), Quaternion.Euler(0, -180, 0));
            timeToCar = Time.time + plusTimeAdd;
        }
    }   
}
