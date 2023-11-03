using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClockHit : MonoBehaviour
{  
    public GameObject gameOverScreen = null;
    private GameOver gameOverScript = null;

    void Awake(){
        gameOverScript = gameOverScreen.GetComponent<GameOver>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Destroy(other.gameObject);
            //TODO: Game over 
            //Stop handles and clock from moving stop 
            // - CHANGE CAMERA - GAME OVER SCREEN - START AGAIN
            if(gameOverScript != null)
            {
                gameOverScript.Show();
            }
            // gameOver = true;
            // gameoverCamera.enabled = true;
            // gameOverText.gameObject.SetActive(true); //hide game over text
            
            // //death
            // playersControllerScript.playerAnim.SetBool("Death_b", true);
            // playersControllerScript.playerAnim.SetInteger("DeathType_int", 1);
            // playersControllerScript.jumpForce = 0f; 

            // //player rotate
            // rotateScript.rotationSpeed = 0f;

            // //handles
            // rotateClockHandlesScript.rotationSpeedHour = 0f;
            // rotateClockHandlesScript.rotationSpeedMinute = 0f;


            //stop handles from moving
           // rotateClockHandlesScript.gameOver = true;
           //rotateClockHandlesScript.gameOver = true;
         /*    rotateClockHandlesScript.RotateHandles(rotateClockHandlesScript.hourHand, 0);
            rotateClockHandlesScript.RotateHandles(rotateClockHandlesScript.minuteHand, 0); */
           
            //stop rotate 
        
  
    }
}
}