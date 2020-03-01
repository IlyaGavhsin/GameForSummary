using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenIconScripts : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;

    public GameObject exp;

    private GameControllerScript gameControllerScript;
    
    void Start()
    {
        Destroy(gameObject, 5.5f) ;
        Rigidbody fallenIconHealth = GetComponent<Rigidbody>();

        fallenIconHealth.velocity = Vector3.back * Speed;
        fallenIconHealth.angularVelocity = new Vector3(0, 0, 1) * RotationSpeed;

        gameControllerScript = GameObject
            .FindGameObjectWithTag("GameController")
            .GetComponent<GameControllerScript>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("yes");
            Instantiate(exp, other.transform.position,Quaternion.identity);
            Destroy(gameObject);
            
            switch (gameControllerScript.Health)
            {
                case 99:
                    break;
                case 66:
                    gameControllerScript.InistiateIconHEalth(3);
                    gameControllerScript.Health = 99;
                    break;
                case 33:
                    gameControllerScript.InistiateIconHEalth(2);
                    gameControllerScript.Health = 66;
                    break;
            }
        }
    }
}
