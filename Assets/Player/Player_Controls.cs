
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public float speedConstant = 0.01f;
    public GameObject DownLimitObject;
    public GameObject LHObject;
    public Joystick JoystickObjcet;
    
    [HideInInspector]
    public bool isControlsActive = false; // TODO after main menu, handle this variable
    private bool playerDownLimit = false;
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

            // If the player has reached to down limit, prevent going further
            if (playerDownLimit && verticalMove < 0)
            {
                verticalMove = 0.0f;
            }

            GetComponent<Transform>().Translate(horizontalMove, 0, 0); // Horizontal
            GetComponent<Transform>().Translate(0, 0, verticalMove); // Vertical
        }

        //////////// Note sure if here is working

        // Check if the player exceed limits
        Transform limit = DownLimitObject.GetComponent<Transform>();
        Transform playerTransform = GetComponent<Transform>();
        if (limit.position.z - playerTransform.position.z > 0)
        {
            playerTransform.SetPositionAndRotation(new Vector3(
                playerTransform.position.x, playerTransform.position.y, limit.position.z + 1),
                playerTransform.rotation
            );
        }
        ///////////
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check game over
        MeshRenderer ms = collision.gameObject.GetComponent<MeshRenderer>();
        if (ms != null && collision.gameObject.layer == 6)
        {
            if (ms.material.color != GetComponent<MeshRenderer>().material.color)
            {
                Debug.Log("END LEVEL");
                
                LHObject.gameObject.GetComponent<LevelHandler>().GameOver();
            }
        }

        // Down limit of player
        if (collision.gameObject.layer == 8)
        {
            playerDownLimit = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Down limit of the player
        if (collision.gameObject.layer == 8)
        {
            playerDownLimit = false;
        }
    }

    // Change color on color changer
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColorChanger"))
        {
            Material mat = GetComponent<MeshRenderer>().material;
            
            if (mat.color == LHObject.GetComponent<LevelHandler>().material_1.color)
            {
                GetComponent<MeshRenderer>().material = LHObject.GetComponent<LevelHandler>().material_2;
            }
            else
            {
                GetComponent<MeshRenderer>().material = LHObject.GetComponent<LevelHandler>().material_1;
            }
        }
    }
}
