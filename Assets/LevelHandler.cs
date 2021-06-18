
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public GameObject PlayerObject;
    public Material material_1;
    public Material material_2;
    public Canvas GameOverCanvas;
    public Canvas GameUICanvas;
    
    [HideInInspector]
    public static bool isGameStarted = false;
    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject.GetComponent<MeshRenderer>().material = material_1;

        // When the game opens, the game is paused
        if (!isGameStarted)
        {
            GameOverCanvas.gameObject.SetActive(true); // Game over menu
            GameUICanvas.gameObject.SetActive(false); // Game UI invisible
            PlayerObject.GetComponent<Player_Controls>().isControlsActive = false; // Disable player movement inputs
            Time.timeScale = 0.0f; // Stop the game
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Game Over
    public void GameOver()
    {
        GameOverCanvas.gameObject.SetActive(true); // Game over menu
        GameUICanvas.gameObject.SetActive(false); // Game UI invisible
        PlayerObject.GetComponent<Player_Controls>().isControlsActive = false; // Disable player movement inputs
        Time.timeScale = 0.0f; // Stop the game
    }

    // Restart the scene
    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene1"); // Reload scene
        GameOverCanvas.gameObject.SetActive(false); // Close canvas
        GameUICanvas.gameObject.SetActive(true); // Game UI visible
        PlayerObject.GetComponent<Player_Controls>().isControlsActive = true; // Enable player movement inputs
        Time.timeScale = 1.0f; // Continue game
        isGameStarted = true;
    }
}

