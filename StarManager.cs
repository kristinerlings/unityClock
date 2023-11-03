using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarManager : MonoBehaviour
{ 
    //https://hub.packtpub.com/arrays-lists-dictionaries-unity-3d-game-development/
    //[SerializeField] 
    
     public GameObject starPrefab; // remember to check if it exists later
    //private List<GameObject> stars = new List<GameObject>(); //create list of stars
     public List<GameObject> stars;
    /*
    items.Add(GameObject);
    items.Remove(GameObject);
    items.Count;
    items.Clear();
    */
    //public TextMeshProUGUI winnerText;  
    //public TextMeshProUGUI scoreText;

    private GameObject currentStar = null;
    private int score;

    public float xRangeMin = 3.5f;  
    public float xRangeMax = 7.5f;  
    private float angleMax = 360.0f; 

    //time
   // private float spawnRate = 1.0f;

    //winner
    public Camera winnerCamera; 
   

    void Awake()
    {
        // Create 5 stars - random locations
       // for (int i = 0; i < 5; i++)
       // {
            float randomAngle = Random.Range(0.0f, angleMax); // Generate a random angle within the specified range
            float randomRad = randomAngle * Mathf.Deg2Rad;
            float x = angleMax * Mathf.Cos(randomRad);
            float z = angleMax * Mathf.Sin(randomRad);



            Vector3 starPosition = new Vector3(x, 0.0f, z);
            GameObject star = Instantiate(starPrefab, starPosition, Quaternion.identity); //create a star
            star.SetActive(false);
            stars.Add(star); //add star to the list
            Debug.Log("Star created at: " + starPosition);
       // }

        // Assign the first star to active and to the currentStar variable
         if (stars.Count > 0)
        {
            currentStar = stars[0];
            currentStar.SetActive(true);
        } 
        // fill list with stars
        // position those stars when creating them
        // Set all stars created to inactive except for the first one
        // assign the first one to the currenstar variable
    }
    
    private void OnTriggerEnter(Collider other){
      
    //  currentStar.SetActive(false);
      Debug.Log("Star set to FALSE");
    }
    

    void Start(){
        //StartCoroutine(SpawnStars());
        score = 0;
        scoreText.text = "Score: " + score;
    }

/*     IEnumerator SpawnStars(){
        while(true){
            yield return new WaitForSeconds(spawnRate);
            float randomAngle = Random.Range(0.0f, angleMax); // Generate a random angle within the specified range
            float randomRad = randomAngle * Mathf.Deg2Rad;
            float x = angleMax * Mathf.Cos(randomRad);
            float z = angleMax * Mathf.Sin(randomRad);
       
    }} */

    void Update()
    {
        if(stars.Count == 0){
            //If the list is empty, game win
            //call whatever when game is over: e.g. camera animation, game over screen, etc.
            Debug.Log("Game Win");
            winnerCamera.enabled = true;
            winnerText.gameObject.SetActive(true); 

            return;
        }

        //if star is a valid object and isn't active, 
        //then destroy from list(JSarray), increase score, put currentStar to the next star in the list (last one in the list)
        // destroy and pop (remove from list back)
        // Set the new currentsStar to active
         if (currentStar != null && !currentStar.activeSelf)
        {
            Debug.Log("Star destroyed");
            Destroy(currentStar);
            stars.Remove(currentStar);
            score++;
            Debug.Log("Score: " + score);

            if (stars.Count > 0)
            {
                int nextStarIndex = stars.Count - 1; // Index of the next star in the list
                currentStar = stars[nextStarIndex];
                currentStar.SetActive(true);
                Debug.Log("New CurrentStar set");
            }
            else
            {
                currentStar = null; // No more stars left in the list
                Debug.Log("No more stars left");
            }
    }
}
}
