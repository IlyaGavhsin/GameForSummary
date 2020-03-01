using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class particaleMove : MonoBehaviour
{
    public GameObject parent;
    private Vector3 pos;
    private void Start()
    {
        pos.y = transform.position.y;
        parent = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() 
    {
        if (parent == null )
        {
            return;
        }
        pos.x = parent.transform.position.x;
        pos.z = parent.transform.position.z - 0.5f ;
        transform.position = pos;


    }
}
