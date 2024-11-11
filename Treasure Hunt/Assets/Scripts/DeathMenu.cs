using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public DeathMenu deathMenu;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab)) // replace with code that detects if player's health bar == 0
        // For now, uses "tab" key to active death screen
        {
            Cursor.lockState = CursorLockMode.None;
            deathMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }


    }
}
