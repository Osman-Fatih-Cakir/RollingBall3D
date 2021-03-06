
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float forwardSpeed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            // Move camear at constant speed
            moveCamera(Time.deltaTime);
    }

    void moveCamera(float delta)
    {
        GetComponent<Transform>().position += delta * (new Vector3(0, 0, forwardSpeed));
    }
}