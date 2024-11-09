using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public Transform teleportDestination;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null && gameManager.HasEnoughTreasures())
            {
                CharacterController controller = player.GetComponent<CharacterController>();
                if (controller != null) controller.enabled = false;

                player.transform.position = teleportDestination.position;
                Debug.Log("Player teleported!");

                if (controller != null) controller.enabled = true;
            }
            else
            {
                Debug.Log("Not enough treasures collected to teleport.");
            }
        }
    }
}
