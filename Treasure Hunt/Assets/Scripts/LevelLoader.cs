using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    // Called when we click the "Level 1" button.
    public void OnLevel1Button ()
    {
        SceneManager.LoadScene(3);
    }    

    // Called when we click the "Level 2" button.
    public void OnLevel2Button ()
    {
        SceneManager.LoadScene(4);
    }    

    // Called when we click the "Level 3" button.
    public void OnLevel3Button ()
    {
        SceneManager.LoadScene(5);
    }    


    // Called when we click the "Level 4" button.
    public void OnLevel4Button ()
    {
        SceneManager.LoadScene(6);
    }    

    // Called when we click the "Back" button.
    public void OnBackButton ()
    {
        SceneManager.LoadScene(0);
    }
    
}