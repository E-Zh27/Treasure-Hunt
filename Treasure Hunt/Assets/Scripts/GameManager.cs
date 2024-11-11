using UnityEngine;
using UnityEngine.UI; // Required for UI elements
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0; 
    public TextMeshProUGUI current;
    public int requiredTreasures = 3; 

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points; 
        UpdateScoreText(); 
    }

    public bool HasEnoughTreasures()
    {
        return score >= requiredTreasures;
    }

    void UpdateScoreText()
    {
        current.text = "Score: " + score; 
    }
}
