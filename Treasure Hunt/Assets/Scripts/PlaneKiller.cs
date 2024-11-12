using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneKiller : MonoBehaviour
{
    public DeathMenu deathMenu;
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            deathMenu.Awake();
            Destroy(other.gameObject); // Destroy the player object as an example
        }
    }
}
