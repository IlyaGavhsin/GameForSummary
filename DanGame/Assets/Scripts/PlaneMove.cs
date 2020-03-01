using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public float speed;
    private Vector3 pos;

    private void Update()
    {
        if(UIDieWin.dieP  || UIDieWin.finP )
        {
            return;
        }
        pos = transform.position;
        pos.z -= speed * Time.deltaTime;
        transform.position = pos;
    }
}
