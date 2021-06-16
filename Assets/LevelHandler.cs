
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject PlayerObject;
    public Material material_1;
    public Material material_2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject.GetComponent<MeshRenderer>().material = material_1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
