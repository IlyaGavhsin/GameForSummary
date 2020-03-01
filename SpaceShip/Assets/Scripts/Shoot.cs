using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject DoubleBulletPrefab;
    public GameObject ArmorPrefab;


    public float shotPower;
    public float DoubleShotPower; 
    private float nexShot = 0;

    public Transform startPoint;
    public Transform leftPoint;
    public Transform rightPoint;
    
    void OnMouseDown()
    {
        GameObject obj = Instantiate(this.bulletPrefab, this.startPoint.position, Quaternion.identity) as GameObject;
        obj.transform.forward = this.startPoint.forward;
        obj.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * this.shotPower);
        Destroy(obj, 0.9f);
    }
    void OnMouseDownTwo()
    {
        GameObject Lobj = Instantiate(this.DoubleBulletPrefab, this.leftPoint.position, this.leftPoint.rotation) as GameObject;
        Lobj.transform.forward = this.leftPoint.forward;
        Lobj.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * this.DoubleShotPower);
        Destroy(Lobj, 0.9f);

        GameObject Robj = Instantiate(this.DoubleBulletPrefab, this.rightPoint.position, this.leftPoint.rotation) as GameObject;
        Robj.transform.forward = this.rightPoint.forward;
        Robj.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * this.DoubleShotPower);
        Destroy(Robj, 0.9f);
    }
    void DownSpaceDown()
    {
        ArmorPrefab.SetActive(true);
    }
    void UpSpaceDown()
    {
        ArmorPrefab.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") & Time.time > nexShot)
        {
            OnMouseDown();
            nexShot = Time.time + 0.2f;
        }
        if (Input.GetButton("Fire2") & Time.time > nexShot)
        {
            OnMouseDownTwo();
            nexShot = Time.time + 0.15f;
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            DownSpaceDown();
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            UpSpaceDown();
        }
    }
}
