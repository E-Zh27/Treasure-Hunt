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
            SceneManager.LoadScene(1);
    }
}
