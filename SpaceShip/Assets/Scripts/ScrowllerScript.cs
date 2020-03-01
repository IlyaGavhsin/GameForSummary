using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrowllerScript : MonoBehaviour
{
    public float speed;
    private GameControllerScript gameControllerScript;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
       
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
        

        var shift = Mathf.Repeat(Time.time * speed, 250);
        transform.position = startPosition + -Vector3.forward * shift;
    }
}
