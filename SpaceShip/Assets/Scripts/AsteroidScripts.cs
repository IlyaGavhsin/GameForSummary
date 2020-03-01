using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScripts : MonoBehaviour
{

    public float rotaion;
    public float minSpeed, maxSpeed;

    public GameObject AsteroidExp;
    public GameObject PlayerExp;
    public int plusScore;
    public int minusHP;

    public GameControllerScript gameControllerScript;
    

    public float timeDestroy;

    void Start()
    {
        Rigidbody astreoid = GetComponent<Rigidbody>();
        astreoid.angularVelocity = Random.insideUnitSphere * rotaion;

        astreoid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);

        switch (this.tag)
        {
            case "asteroid1":
                Destroy(gameObject, timeDestroy);
                break;
            case "asteroid2":
                Destroy(gameObject, timeDestroy);
                break;
            case "asteroid3":
                Destroy(gameObject, timeDestroy);
                break;
        }
        gameControllerScript = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameControllerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            
            Instantiate(AsteroidExp, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameControllerScript.increasScore(plusScore);
        }
        if (other.tag == "Armor")
        {
            Instantiate(AsteroidExp, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gameControllerScript.increasScore(plusScore);

        }
        if (other.tag == "Player")
        {
            
            gameControllerScript.MinusHealth(minusHP);
            if (gameControllerScript.Health == 66 )
            {
                gameControllerScript.DestroyIconHEalth(3);
                Instantiate(AsteroidExp, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Debug.Log("Я задел 66");
            }
            if (gameControllerScript.Health == 33)
            {
                gameControllerScript.DestroyIconHEalth(2);
                gameControllerScript.DestroyIconHEalth(3);
                Instantiate(AsteroidExp,gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Debug.Log("Я задел его 33");
            }
            if (gameControllerScript.Health <= 0)
            {
                gameControllerScript.DestroyIconHEalth(1);
                gameControllerScript.DestroyIconHEalth(2);
                gameControllerScript.DestroyIconHEalth(3);
                Vector3 posZ = new Vector3(transform.position.x, transform.position.y, transform.position.z + 20f);

                Instantiate(AsteroidExp, posZ, Quaternion.identity);
                Instantiate(PlayerExp, other.transform.position, Quaternion.identity);

                Destroy(other.gameObject);
                Destroy(gameObject);

                gameControllerScript.ChangeBool(false);
                gameControllerScript.ActiveGameOverText();
                gameControllerScript.RestartBottonGO.SetActive(true);
                Debug.Log("Я задел его die");

            }


        }
    }

}
