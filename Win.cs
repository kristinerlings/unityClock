using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Win : MonoBehaviour
{
    public TextMeshProUGUI winnerText;  
    public TextMeshProUGUI scoreText;

    //winner
    public Camera winnerCamera; 
    
    void Awake()
    {
        winnerCamera.enabled = false;
        winnerText.gameObject.SetActive(false); //hide game over text
        scoreText.gameObject.SetActive(false);
    }

    public void Show()
    {
        winnerCamera.enabled = true;
        winnerText.gameObject.SetActive(true); //hide game over text
        scoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
}
