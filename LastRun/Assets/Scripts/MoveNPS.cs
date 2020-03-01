using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPS : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float speed;
    public List<GameObject> wheels;
    private bool touchPlayer;
    Rigidbody rb;
    private void Start()
    {
         rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!touchPlayer)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(speed * 10f, 0, 0);
            }
        }
        else
        {

            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(rb.velocity.z, 0, 0);
            }
        }
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Car")
        {
            rb.velocity = transform.forward * speed;
            touchPlayer = true;
        }
    }
}
