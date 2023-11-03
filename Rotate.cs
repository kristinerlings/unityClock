using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // private ClockHit ClockHitScript; //reference to the player controller script


   /* [SerializeField]*/
    public float rotationSpeed = 100f;


   /*   void Start()
    {
        ClockHitScript = GameObject.Find("Player").GetComponent<ClockHit>(); //find the player game object and get the player controller script (finds name of object in my scene hiarchy)
    } */

    // Update is called once per frame
    void Update()
    {
       // if(ClockHitScript.gameOver == false)
       // {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
       // }
       

    }
}
