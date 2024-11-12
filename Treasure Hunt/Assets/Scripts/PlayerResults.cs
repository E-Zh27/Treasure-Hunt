using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerResults : MonoBehaviour
{
    public GameManager gameManager;  // Reference to the GameManager object
    public DeathMenu deathMenu;

    void Update()
    {
        CheckGameProgress();
    }

    // Method to call when the player dies
    public void PlayerDied()
    {
        deathMenu.Update();
    }

    // Check if the player has enough treasures to complete the level
    private void CheckGameProgress()
    {
        //Idk what scene we are suppose to go to
        if (gameManager != null && gameManager.HasEnoughTreasures())
            SceneManager.LoadScene(1);
    }
}
