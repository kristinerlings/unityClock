using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClockHit : MonoBehaviour
{  
    public GameObject gameOverScreen = null;
    private GameOver gameOverScript = null;
    private AudioSource audioSource;
    public AudioClip crashSound;

    void Awake(){
        gameOverScript = gameOverScreen.GetComponent<GameOver>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            if(gameOverScript != null)
            {
                gameOverScript.Show();
            }
            audioSource.PlayOneShot(crashSound, 1.0f);
        
  
    }
}
}