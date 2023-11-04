using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private PlayersController playersControllerScript;
    private Rotate rotatePlayer = null;

    // Get all obj. with tag ClockHand
    private List<Rotate> clockRotateList = new List<Rotate>();

    public Camera gameoverCamera; 
    public TextMeshProUGUI gameOverText;

    public Button restartButton;


    void Start(){
        playersControllerScript = GameObject.Find("Player").GetComponent<PlayersController>(); 
        rotatePlayer = GameObject.Find("PlayerWrapper").GetComponent<Rotate>();

        // Get all objects with the tag ClockHand
        // Get their Rotate component and add it to the list
        foreach (GameObject clockHand in GameObject.FindGameObjectsWithTag("ClockHand"))
        {
            clockRotateList.Add(clockHand.GetComponent<Rotate>());
        }
        restartButton.gameObject.SetActive(true); 
        gameOverText.gameObject.SetActive(false); 
     } 


    public void RestartTheGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void Show()
    {
        gameObject.SetActive(true);

        // Stop movement
        rotatePlayer.rotationSpeed = 0f;
        foreach(Rotate clockRotate in clockRotateList)
        {
            clockRotate.rotationSpeed = 0f;
        }

        // GameOver screen
        gameoverCamera.enabled = true;
        gameOverText.gameObject.SetActive(true);
        
            
        // Animation - player
        playersControllerScript.playerAnim.SetBool("Death_b", true);
        playersControllerScript.playerAnim.SetInteger("DeathType_int", 1);
        playersControllerScript.allowControl = false; //stop player from moving
       
    }


}
