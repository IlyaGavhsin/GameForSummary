using UnityEngine;

public class Move : MonoBehaviour
{
    [HideInInspector]
    public Vector3 nowPos;
    static public bool isLive = true;
    //Speed
    [Header("Speed")]
    public float MinSpeed;
    public float MaxSpeed;
    public float UpSpeed;
    public float DownSpeed;
    public float angularSpeed;
    //Border
    [Header("Border")]
    public float xMin;
    public float xMax;
    //Wheels
    [Header("Wheels")]
    public GameObject[] wheels;
    public float boostWheelSpeed;





    [Header("Set Dynamicaly")]
    public float speed;
    public bool bidAng = false;
    public bool Triggered = false;
    private bool was = false;
    private float timeAd;

    private float xTransfom;
    private float yTransform;
    private Vector3 pos;
    private Quaternion rot;
    private Rigidbody rb;
    public float yMinRot;
    public float yMaxRot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = MinSpeed;
        wheels = GameObject.FindGameObjectsWithTag("wheel");
    }
    private void Update()
    {
        nowPos = transform.position;
        //After collision
        if (Triggered)
        {
            if (!was)
            {
                if (speed > 100f & speed < 150f)
                {
                    rb.velocity = transform.forward * (speed - 80f);
                    was = true;
                    isLive = false;
                    return;
                }
                if (speed > 151f)
                {
                    rb.velocity = transform.forward * (speed - 120);
                    was = true;
                    isLive = false;
                    return;
                }
                if (speed < 100f & speed > 60f)
                {
                    rb.velocity = transform.forward * (speed - 40);
                    was = true;
                    isLive = false;
                    return;
                }
                if(speed < 60f)
                {
                    rb.velocity = transform.forward * (speed - 20f);
                    was = true;
                    isLive = false;
                    return;
                }

            }
            return;
        }

        BorderMethod();
        //    Position.z
        xTransfom = Input.GetAxis("Vertical");
        if (xTransfom != 0)
        {
            if (xTransfom > 0)
            {
                speed += xTransfom * UpSpeed * Time.deltaTime;
            }
            if (xTransfom < 0)
            {
                speed -= (DownSpeed + 70f) * Time.deltaTime;
            }
        }

        else
        {
            speed -= DownSpeed * Time.deltaTime;
        }
        if (speed > MaxSpeed || speed < MinSpeed)
        {
            speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);
        }

        //UpSpeed

        if (speed <= 100f)
        {
            UpSpeed = 15f;
        }
        if (speed > 100f & speed < 150f)
        {
            UpSpeed = 10f;
        }
        if (speed > 150f)
        {
            UpSpeed = 5f;
        }
        else
        {
            UpSpeed = 15f;
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        foreach (GameObject wheel in wheels)
        {

            wheel.transform.Rotate(Mathf.Abs(speed * boostWheelSpeed), 0, 0);
        }
        //Rotation


        if (transform.rotation.y > yMinRot)
        {
            if (Input.GetKey(KeyCode.A))
            {
                pos = transform.position;
                pos.x -= angularSpeed * Time.deltaTime;
                transform.position = pos;
                //transform.Rotate(new Vector3(0, -angularSpeed , 0) * Time.deltaTime);
            }
            //else
            //{
            //    //if (this.transform.rotation.y < 0)
            //    //{
            //    //    transform.Rotate(new Vector3(0, angularSpeed + 10f, 0) * Time.deltaTime);
            //   // }
            //}
        }

        if (transform.rotation.y < yMaxRot)
        {
            if (Input.GetKey(KeyCode.D))
            {
                pos = transform.position;
                pos.x += angularSpeed * Time.deltaTime;
                transform.position = pos;
                //transform.Rotate(new Vector3(0, angularSpeed  , 0) * Time.deltaTime);
            }
            //else
            //   {
            ////    if(this.transform.rotation.y > 0)
            ////    {
            ////        transform.Rotate(new Vector3(0, -angularSpeed - 10f, 0) * Time.deltaTime);
            ////    }
            //}
        }

        transform.rotation = Quaternion.identity;

        BorderMethod();


    }
    private void LateUpdate()
    {
        BorderMethod();
    }
    private void BorderMethod()
    {
        if (transform.position.x > xMax)
        {
            pos = transform.position;
            pos.x = xMax;
            transform.position = pos;
        }
        if (transform.position.x < xMin)
        {
            pos = transform.position;
            pos.x = xMin;
            transform.position = pos;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
        {
            Triggered = true;
        }
    }

}
