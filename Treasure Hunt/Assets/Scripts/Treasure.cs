using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int points = 0; // Points to add when collected

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("yes");
            GameManager gameManager = FindObjectOfType<GameManager>(); // Find the GameManager
            if (gameManager != null)
            {
                gameManager.AddScore(points); // Add points to the score
            }
            Destroy(gameObject); // Remove the treasure
        }
    }
}
