using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScreen : MonoBehaviour
{
    
    public PauseMenu pauseMenu;

    // Called when we click the "Resume" button.
    public void OnResumeButton ()
    {
        pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
        Time.timeScale = 1;
    }
    
    // Called when we click the "Main Menu" button.
    public void OnMainMenuButton ()
    {
        SceneManager.LoadScene(0);
    }
}