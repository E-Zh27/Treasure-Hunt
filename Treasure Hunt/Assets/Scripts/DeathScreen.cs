using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
   // Called when we click the " 

    // Called when we click the "Retry" button.
    public void OnRetryButton ()
    {

    }
    
    // Called when we click the "Main Menu" button.
    public void OnMainMenuButton ()
    {
        SceneManager.LoadScene(0);
    }
}