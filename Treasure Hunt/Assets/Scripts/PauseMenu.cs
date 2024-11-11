using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PauseMenu pauseMenu;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !pauseMenu.isActiveAndEnabled)
        {
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
            Time.timeScale = 0;
        }
    }
}
