using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //interact with ui 

public class GameOver : MonoBehaviour
{
    private PlayersController playersControllerScript;
    private Rotate rotatePlayer = null;
    private List<Rotate> clockRotateList = new List<Rotate>();

    public Camera gameoverCamera; 
    public TextMeshProUGUI gameOverText;

    //ui button restart game
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
        restartButton.gameObject.SetActive(true); //show restart button
        gameOverText.gameObject.SetActive(false); //hide game over text
     } 


    public void RestartTheGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void Show()
    {
        //TODO: Game over 
        gameObject.SetActive(true);

        // Stop movement
        rotatePlayer.rotationSpeed = 0f;
        foreach(Rotate clockRotate in clockRotateList)
        {
            clockRotate.rotationSpeed = 0f;
        }

        // - CHANGE CAMERA - GAME OVER SCREEN - START AGAIN
        gameoverCamera.enabled = true;
        gameOverText.gameObject.SetActive(true); //show game over text
        
            
        //death
        playersControllerScript.playerAnim.SetBool("Death_b", true);
        playersControllerScript.playerAnim.SetInteger("DeathType_int", 1);
        //playersControllerScript.jumpForce = 0f; 
        playersControllerScript.allowControl = false; //stop player from moving
       
    }


}
