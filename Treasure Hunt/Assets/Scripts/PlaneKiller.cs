using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneKiller : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Logic for the player "dying" (e.g., reload the scene, disable player, etc.)
            Destroy(other.gameObject); // Destroys the player object as an example
            Debug.Log("Player has died.");
        }
    }
}
