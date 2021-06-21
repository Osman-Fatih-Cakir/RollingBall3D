
using UnityEngine;

public class LevelSc : MonoBehaviour
{
    public GameObject LHObject;

    // Start is called before the first frame update
    void Start()
    {
        // Get materials from level handler
        Material material_1 = LHObject.GetComponent<LevelHandler>().material_2;
        Material material_2 = LHObject.GetComponent<LevelHandler>().material_1;

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

