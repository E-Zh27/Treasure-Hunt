using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
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
            else
            {
                Debug.Log("Not enough treasures collected to teleport.");
            }
        }
    }
}
