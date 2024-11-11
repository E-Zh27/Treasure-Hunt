using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerResults : MonoBehaviour
{
    public GameManager gameManager;  // Reference to the GameManager object

    void Update()
    {
        CheckGameProgress();
    }

    // Method to call when the player dies
    public void PlayerDied()
    {
        SceneManager.LoadScene(1);
    }

    // Check if the player has enough treasures to complete the level
    private void CheckGameProgress()
    {
        if (gameManager != null && gameManager.HasEnoughTreasures())
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    // Load the next scene in the build order
                    SceneManager.LoadScene(nextSceneIndex);
                    Debug.Log("Loading next scene...");
                }
                else
                {
                    // If no more scenes, load the main menu (first scene)
                    SceneManager.LoadScene(0);
                    Debug.Log("Returning to main menu...");
                }
            }
    }
}
