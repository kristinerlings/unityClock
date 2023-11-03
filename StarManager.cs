using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{ 
    //https://hub.packtpub.com/arrays-lists-dictionaries-unity-3d-game-development/
    //[SerializeField] 
    
     public GameObject starPrefab; // remember to check if it exists later
     private List<GameObject> stars = new List<GameObject>(); //create list of stars
     /*
    items.Add(GameObject);
    items.Remove(GameObject);
    items.Count;
    items.Clear();
    */
     public int nrStars = 5; //number of stars

    private GameObject currentStar = null;

    public float xRangeMin = 3.5f;  
    public float xRangeMax = 7.5f;  
    private float angleMax = 360.0f; 
    private int score = 0;

    //winner
    public GameObject winnerScreen = null;
    private Win winScreenScript = null; 
   

    void Awake()
    {
        if(starPrefab == null)
        {
            Debug.LogError("Star prefab is not assigned!");
            return;
        }

        if(winnerScreen != null)
        {
            winScreenScript = winnerScreen.GetComponent<Win>();
        }

        // Create stars - random locations
        for (int i = 0; i < nrStars; i++)
        {
            float randomAngle = Random.Range(0.0f, angleMax) * Mathf.Deg2Rad; // Generate a random angle within the specified range
            float randomRadius = Random.Range(xRangeMin, xRangeMax); // Generate a random radius within the specified range

            float x = randomRadius * Mathf.Cos(randomAngle);
            float z = randomRadius * Mathf.Sin(randomAngle);

            GameObject star = Instantiate(starPrefab); //create a star
            star.transform.position = new Vector3(x, transform.position.y, z); //set the position of the star
            star.SetActive(false);
            stars.Add(star); //add star to the list
        }

        // Assign the first star to active and to the currentStar variable
        UpdateStar();
    }

    void Update()
    {
        if(currentStar == null)
        {
            return;
        }

        if(!currentStar.activeSelf)
        {
            UpdateStar();
            score++;
        }  
    }

    void UpdateStar()
    {
        if(currentStar != null)
        {
            stars.Remove(currentStar);
            Destroy(currentStar);
        }

        // Get next star if the list is not empty
        if(stars.Count > 0)
        {
            currentStar = stars[0];
            currentStar.SetActive(true);
        }
        else
        {
            // Show winscreen
            winScreenScript.UpdateScore(score);
            winScreenScript.Show();
        }
    }
}
