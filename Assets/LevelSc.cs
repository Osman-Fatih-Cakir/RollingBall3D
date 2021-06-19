
using UnityEngine;

public class LevelSc : MonoBehaviour
{
    public Material material_1;
    public Material material_2;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize materials for that level
        GameObject f1 = GetComponent<Transform>().GetChild(0).gameObject;
        GameObject f2 = GetComponent<Transform>().GetChild(1).gameObject;
        for (int i = 0; i < f1.transform.childCount; i++) // First colored objects
        {
            f1.transform.GetChild(i).GetComponent<MeshRenderer>().material = material_1;
        }
        for (int i = 0; i < f2.transform.childCount; i++) // Second colored objects
        {
            f2.transform.GetChild(i).GetComponent<MeshRenderer>().material = material_2;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

