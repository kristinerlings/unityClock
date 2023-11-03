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
            if(gameOverScript != null)
            {
                gameOverScript.Show();
            }
        
  
    }
}
}