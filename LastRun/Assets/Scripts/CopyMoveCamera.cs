using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMoveCamera : MonoBehaviour
{
    public GameObject ob;
    private Vector3 pos;
    void Start()
    {
        ob = GetComponent<GameObject>();
    }
    void Update()
    {
        pos.z = ob.transform.position.z;
        transform.position = pos;
    }
}
