
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public float speedConstant = 0.01f;
    public GameObject DownLimitObject;
    public GameObject LHObject;
    public Joystick JoystickObjcet;
    
    [HideInInspector]
    public bool isControlsActive = false; // TODO after main menu, handle this variable
    private bool downLimit = false;
    private bool leftLimit = false;
    private bool rightLimit = false;
    private float horizontalMove = 0.0f;
    private float verticalMove = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Starting material
        GetComponent<MeshRenderer>().material = LHObject.GetComponent<LevelHandler>().material_1;

        isControlsActive = true; // TODO change it from here to level loading
    }

    // Update is called once per frame
    void Update()
    {
        // Move player with joystick
        if (isControlsActive)
        {
            horizontalMove = JoystickObjcet.Horizontal * speedConstant;
            verticalMove = JoystickObjcet.Vertical * speedConstant;

            // If the player has reached to a limit, prevent going further
            if (downLimit && verticalMove < 0)
            {
                verticalMove = 0.0f;
            }
            if (leftLimit && horizontalMove < 0)
            {
                horizontalMove = 0.0f;
            }
            if (rightLimit && horizontalMove > 0)
            {
                horizontalMove = 0.0f;
            }

            GetComponent<Transform>().Translate(horizontalMove, 0, 0); // Horizontal move
            GetComponent<Transform>().Translate(0, 0, verticalMove); // Vertical move
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check game over
        MeshRenderer ms = collision.gameObject.GetComponent<MeshRenderer>();
        if (ms != null && collision.gameObject.layer == 6)
        {
            if (ms.material.color != GetComponent<MeshRenderer>().material.color)
            {
                LHObject.gameObject.GetComponent<LevelHandler>().GameOver();
            }
        }

        // Limits of player
        if (collision.gameObject.tag == "LeftLimit")
        {
            leftLimit = true;
        }
        else if (collision.gameObject.tag == "RightLimit")
        {
            rightLimit = true;
        }
        else if (collision.gameObject.tag == "DownLimit")
        {
            downLimit = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Limits of the player
        if (collision.gameObject.tag == "LeftLimit")
        {
            leftLimit = false;
        }
        else if (collision.gameObject.tag == "RightLimit")
        {
            rightLimit = false;
        }
        else if (collision.gameObject.tag == "DownLimit")
        {
            downLimit = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLimit")
        {
            // Level is done
            LHObject.GetComponent<LevelHandler>().GameOver();
        }
    }
}
