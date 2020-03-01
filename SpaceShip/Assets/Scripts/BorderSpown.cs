using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderSpown : MonoBehaviour
{
    public GameObject fallIconHealf;
    public float nextTimeInstFall = 5f;

    public GameObject asteroidOne;
    public GameObject asteroidTwo;
    public GameObject asteroidThree;

    public float minDelay, maxDelay;
    public float nextLaunch;

    private float randomAsteroid;

    

    public GameControllerScript gameControllerScript;

    void Start()
    {
        gameControllerScript = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameControllerScript>();
    }

    void Update()
    {

        
        if (!gameControllerScript.getIsStarted())
        {
            return;
        }
        if (Mathf.Round(Time.time) > nextTimeInstFall )
        {
            var halfWidth = transform.localScale.x / 2;
            var positionX = Random.Range(-halfWidth, halfWidth);
            var newFallenIconPosition = new Vector3(
                positionX,
                transform.position.y,
                transform.position.z);
            Instantiate(fallIconHealf, newFallenIconPosition, Quaternion.identity);
            nextTimeInstFall = Mathf.Round(Time.time) + 20f;

        }
        if (Time.time > nextLaunch)
        {
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);

            var halfWidth = transform.localScale.x / 2;
            var positionX = Random.Range(-halfWidth, halfWidth);

            var newAsteroidPosition = new Vector3(
                positionX,
                transform.position.y,
                transform.position.z);

            randomAsteroid = Random.Range(1,8);
            switch (randomAsteroid)
            {
                case 1 :
                    Instantiate(asteroidOne, newAsteroidPosition, Quaternion.identity);
                    break;
                case 2  :
                    Instantiate(asteroidTwo, newAsteroidPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(asteroidTwo, newAsteroidPosition, Quaternion.identity);                         //Theory вероятности при у первого астероида одная/7
                    break;                                                                                       //Theory вероятности при у второго  астероида три/7, у третьего 2/7
                case 4:
                    Instantiate(asteroidTwo, newAsteroidPosition, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(asteroidThree, newAsteroidPosition, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(asteroidThree, newAsteroidPosition, Quaternion.identity);
                    break;
                case 7:
                    Instantiate(asteroidThree, newAsteroidPosition, Quaternion.identity);
                    break;
            }
        }

    }
    public void PlusNetTimeInstFall()
    {
        nextTimeInstFall = Mathf.Round(Time.time) + 5f;
    }
}
