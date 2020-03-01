using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoudBlock : MonoBehaviour
{
    private bool res = false;
    

    public bool Fetch(float z)
    {
        res = false;
        if (z > transform.position.z + 370)
        {
            res = true;
        }
        return res;
    }
    public void Delete()
    {
        Destroy(gameObject);
    }
}
