
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public float speedConstant = 0.01f;

    public GameObject DownLimitObject;
    public GameObject LHObject;

    public Material PlayerMaterial;

    private bool playerDownLimit = false;
    private float downSpeed = 1.0f;
    private float rightSpeed = 1.0f;
    private float leftSpeed = 1.0f;
    private float upSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Starting material
        GetComponent<MeshRenderer>().material = LHObject.GetComponent<LevelHandler>().material_1;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            // Move player
            if (touch.deltaPosition.x > 0.01) // Right
            {
                GetComponent<Transform>().Translate(touch.deltaPosition.x * speedConstant * rightSpeed, 0, 0);
            }
            else if (touch.deltaPosition.x < -0.01) // Left
            {
                GetComponent<Transform>().Translate(touch.deltaPosition.x * speedConstant * leftSpeed, 0, 0);
            }
            if (touch.deltaPosition.y < -0.01) // Down
            {
                if (playerDownLimit)
                    downSpeed = 0.0f;
                else
                    downSpeed = 1.0f;
                GetComponent<Transform>().Translate(0, 0, touch.deltaPosition.y * speedConstant * downSpeed);
            }
            else if (touch.deltaPosition.y > 0.01 ) // Up
            {
                GetComponent<Transform>().Translate(0, 0, touch.deltaPosition.y * speedConstant * upSpeed);
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
