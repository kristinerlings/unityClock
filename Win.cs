using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //interact with ui 

public class Win : MonoBehaviour
{
    public TextMeshProUGUI winnerText;  
    //public TextMeshProUGUI scoreText; //not sure I want here - take away later

    //reference other scripts:
    private PlayersController playersControllerScript;
    //private Rotate rotatePlayer = null;

    private List<Rotate> clockRotateList = new List<Rotate>(); //type of rotate items: clockhandles
    

    //winner
    public Camera winnerCamera; 
    public Button restartButton;


    
    void Awake()
    {
        winnerCamera.enabled = false;
        winnerText.gameObject.SetActive(false); //hide game over text
       // scoreText.gameObject.SetActive(false);

        playersControllerScript = GameObject.Find("Player").GetComponent<PlayersController>(); 

       // rotatePlayer = GameObject.Find("PlayerWrapper").GetComponent<Rotate>();

        // Get all objects with the tag ClockHand
        // Get their Rotate component and add it to the list
        foreach (GameObject clockHand in GameObject.FindGameObjectsWithTag("ClockHand"))
        {
            clockRotateList.Add(clockHand.GetComponent<Rotate>());
        }

        
    }

    public void Show()
    {
        winnerCamera.enabled = true;
        winnerText.gameObject.SetActive(true); //hide game over text
        //scoreText.gameObject.SetActive(true);
       
        playersControllerScript.allowControl = false; //stop player
        // idle animation 
      

        // Stop movement player
       // rotatePlayer.rotationSpeed = 0f;
        // stop movement clock
       foreach(Rotate clockRotate in clockRotateList){
            clockRotate.rotationSpeed = 0f;
            clockRotate.gameObject.SetActive(false); //handles disappear
        } 
    

        

        //GameObject.FindWithTag("ClockHand").SetActive(false); //handles disappear
    }

    public void RestartTheGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /* public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    } */
}
