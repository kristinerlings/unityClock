using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] GameObject starPrefab; // remember to check if it exists later
    private List<GameObject> stars = new List<GameObject>();
    private GameObject currentStar = null;

    void Awake()
    {
        // fill list with stars
        // position those stars when creating them
        // Set all stars created to inactive except for the first one
        // assign the first one to the currenstar variable
    }

    void Update(){
        
        if(stars.Count == 0){
            //If the list is empty, game win
            //call whatever when game is over: e.g. camera animation, game over screen, etc.
            return;
        }

        //if star is a valid object and isn't active, 
        //then destroy from list(JSarray), increase score, put currentStar to the next star in the list (last one in the list)
        // destroy and pop (remove from list back)
        // Set the new currentsStar to active
        if(currentStar != null && !currentStar.activeSelf){
            return;
        }
    }
}
