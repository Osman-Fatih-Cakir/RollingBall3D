
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public GameObject PlayerObject;
    public Material material_1;
    public Material material_2;
    public Canvas GameOverCanvas;

    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject.GetComponent<MeshRenderer>().material = material_1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Game Over
    public void GameOver()
    {
        GameOverCanvas.gameObject.SetActive(true); // Game over menu

        Time.timeScale = 0.0f; // Stop the game
    }

    // Restart the scene
    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene1"); // Reload scene
        GameOverCanvas.gameObject.SetActive(false); // Close canvas
        Time.timeScale = 1.0f; // Continue game
    }
}
