using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMove : MonoBehaviour
{
    public GameObject ob;
    private Vector3 pos;
    private Vector3 pos2;
    private bool was;
    
     Camera cam;

    private Vector3 newPosOb;
    private Vector3 oldPosOb;
    private float result;

    private void Start()
    {
        cam = Camera.main;
        ob = GameObject.FindGameObjectWithTag("Player");
        oldPosOb = ob.transform.position;
        pos = transform.position;
    }
    private void Update()
    {
        if (!Move.isLive)
        {
            if(cam.fieldOfView < 80f)
            {
                cam.fieldOfView += 20f * Time.deltaTime;
            }
        }
    }
    void LateUpdate()
    {
        if (Move.isLive)
        {
            newPosOb = ob.transform.position;
            pos.z += GetMultiplyPos(newPosOb);
            transform.position = pos;
        }
        
            
            
    }

    private float GetMultiplyPos(Vector3 newPos)
    {
        result = newPos.z - oldPosOb.z;
        oldPosOb = newPos;
        return result;

    }
}
