using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public AudioManager ambientSound;
    // Called when we click the "Level 1" button.
    public void OnLevel1Button ()
    {
        Destroy(GameObject.Find("AmbientSound"));
        SceneManager.LoadScene(3);
    }    

    // Called when we click the "Level 2" button.
    public void OnLevel2Button ()
    {
        Destroy(GameObject.Find("AmbientSound"));
        SceneManager.LoadScene(4);

    }    

    // Called when we click the "Level 3" button.
    public void OnLevel3Button ()
    {
        Destroy(GameObject.Find("AmbientSound"));
        SceneManager.LoadScene(5);

    }    

    // Called when we click the "Back" button.
    public void OnBackButton ()
    {
        SceneManager.LoadScene(0);
    }
    
}