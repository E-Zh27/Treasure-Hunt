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
            Debug.Log("Player has collided with the plane.");
            Destroy(other.gameObject); // Destroy the player object as an example
            Debug.Log("Player has died.");
        }
        else
        {
            Debug.Log("Non-player object collided with the plane.");
        }
    }
}
