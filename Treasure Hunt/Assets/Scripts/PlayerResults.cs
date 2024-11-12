using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerResults : MonoBehaviour
{
    public GameManager gameManager;  
    private bool levelCompleted = false;  
    private int nextSceneIndex;  

    private void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update()
    {
        if (!levelCompleted)
        {
            CheckGameProgress();
        }
    }

    private void CheckGameProgress()
    {
        if (gameManager != null && gameManager.HasEnoughTreasures())
        {
            levelCompleted = true;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
                Debug.Log("Loading next scene...");
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
