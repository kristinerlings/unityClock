using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{ 
    
     public GameObject starPrefab; //create a star
     private List<GameObject> stars = new List<GameObject>(); //create list of stars
     private AudioSource audioSource;
     public AudioClip starSound;
     /*
    items.Add(GameObject);
    items.Remove(GameObject);
    items.Count;
    items.Clear();
    */
     public int nrStars = 5; 

    private GameObject currentStar = null;

    public float xRangeMin = 3.5f;  
    public float xRangeMax = 7.5f;  
    private float rotationMax = 360.0f; 
    public int score = 0;
    private PlayersController playersControllerScript;

    //winner
    public GameObject winnerScreen = null;
    private Win winScreenScript = null; 
   

    void Awake()
    {
        playersControllerScript = GameObject.Find("Player").GetComponent<PlayersController>();
        audioSource = GetComponent<AudioSource>();
        if(starPrefab == null){
            Debug.LogError("Star prefab is not assigned!");
            return;
        }

        if(winnerScreen != null){
            winScreenScript = winnerScreen.GetComponent<Win>();
        }

        // Create stars - random locations
        for (int i = 0; i < nrStars; i++){
            // Generate random position (angle + radius) within specific range
            float randomAngle = Random.Range(0.0f, rotationMax) * Mathf.Deg2Rad; 
            float randomRadius = Random.Range(xRangeMin, xRangeMax);

            float x = randomRadius * Mathf.Cos(randomAngle);
            float z = randomRadius * Mathf.Sin(randomAngle);

            //Create star, set position and add to list
            GameObject star = Instantiate(starPrefab);
            star.transform.position = new Vector3(x, transform.position.y, z);
            star.SetActive(false);
            stars.Add(star); 
        }

        UpdateStar();
   
    }

    void Update()
    {
        if(currentStar == null){
            return;
        }

        if(!currentStar.activeSelf){
            UpdateStar();
            score++;
            Debug.Log("Score: " + score);
            audioSource.PlayOneShot(starSound, 1.0f);
            playersControllerScript.scoreText.text = "Stars: " + score + "/" + nrStars;
        }  
        
    }

    void UpdateStar()
    {  // Hide/destroy current star
        if(currentStar != null){
            stars.Remove(currentStar);
            Destroy(currentStar);
        }

        // Get next star if the list is not empty
        if(stars.Count > 0){
            currentStar = stars[0];
            currentStar.SetActive(true);
        }
        //  empty = WINNER
        else{
           playersControllerScript.scoreText.text = "Stars: " + score + "/" + nrStars;
           winScreenScript.Show();
           audioSource.PlayOneShot(starSound, 1.0f);
        }
    }

}
