
using UnityEngine;

public class ColorChangerSc : MonoBehaviour
{
    public Material material_1;
    public Material material_2;

    // Start is called before the first frame update
    void Start()
    {
        // Change quads colors
        GetComponent<Transform>().GetChild(2).gameObject.GetComponent<MeshRenderer>().material = material_1;
        GetComponent<Transform>().GetChild(3).gameObject.GetComponent<MeshRenderer>().material = material_2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
