using UnityEngine;

public class MoveScripts : MonoBehaviour
{
    [SerializeField]
    private float ShipSpeed = 10f;

    [SerializeField]
    private float TiltSpeed;

    [SerializeField]
    private float xMin, xMax, zMin, zMax;

    Rigidbody ship;
    public GameControllerScript gameControllerScript;

    void Start()
    {
        ship = GetComponent<Rigidbody>();
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
        var MoveHorizontal = Input.GetAxis("Horizontal");
        var MoveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(MoveHorizontal, 0, MoveVertical) * ShipSpeed;

        ship.rotation = Quaternion.Euler(MoveVertical * TiltSpeed, 0, -MoveHorizontal * TiltSpeed);

        var xPos = Mathf.Clamp(ship.position.x, xMin, xMax);
        var zPos = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(xPos, 0, zPos);


    }
}
