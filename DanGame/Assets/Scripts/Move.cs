using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    [HideInInspector]
    [Header("Set Dynamically")]
    public bool WasStart = false;
    public float firstSpeed;
    public GameObject prefDie;
    public GameObject finish;


    private Vector3 pos;
    private Vector3 borderPos;
    private float xMax = 12.5f;
    private float xMin = -9f;
    private float zMin = -17.5f;
    private void Start()
    {
        xMax = 12.5f;
        xMin = -9f;
        zMin = -17.5f;
        
    }
     void Update()
    {
        if(transform.position.z > finish.transform.position.z + 10f)
        {
            UIDieWin.finP = true;
            return;
        }
        if (!WasStart)
        {
                pos = transform.position;
                pos.z += Time.deltaTime * firstSpeed;
                transform.position = pos;
        }
        if (Input.touchCount > 0)
        {
               WasStart = true;
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    pos = transform.position;
                    pos.x += touch.deltaPosition.x * touch.deltaTime * 0.85f;
                    pos.z += touch.deltaPosition.y * touch.deltaTime * 0.85f;
                    SetBorder();
                    transform.position = pos;
                    break;
            }
        }
        
    }



    private void LateUpdate()
    {

        if (transform.position.x > xMax)
        {
            borderPos = transform.position;
            borderPos.x = xMax;
            transform.position = borderPos;

        }
        if (transform.position.x < xMin)
        {
            borderPos = transform.position;
            borderPos.x = xMin;
            transform.position = borderPos;

        }
        if (transform.position.z < zMin)
        {
            borderPos = transform.position;
            borderPos.z = zMin;
            transform.position = borderPos;
        }
        if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
    private void SetBorder()
    {
        if (pos.x > xMax)
        {
            pos.x = xMax;
        }
        if (pos.x < xMin)
        {
            pos.x = xMin;
        }
        if (pos.z < zMin)
        {
            pos.z = zMin;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(prefDie, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
