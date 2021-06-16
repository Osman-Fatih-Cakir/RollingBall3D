
using UnityEngine;

public class ColorChangerSc : MonoBehaviour
{
    public GameObject LHObject;

    // Start is called before the first frame update
    void Start()
    {
        // Change quads colors
        GetComponent<Transform>().GetChild(2).gameObject.GetComponent<MeshRenderer>().material = LHObject.GetComponent<LevelHandler>().material_2;
        GetComponent<Transform>().GetChild(3).gameObject.GetComponent<MeshRenderer>().material = LHObject.GetComponent<LevelHandler>().material_1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
