using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
   // Player movement 
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRangeMin = 3.5f;  
    public float xRangeMax = 8.45f;  
 
   //player jump
    public float jumpForce = 10.0f;
    public bool isJumping = false; 



    // Start is called before the first frame update
    void Start()
    {

        
    }

    void Jump(){
       if (!isJumping){
            //add force to the player
            isJumping = true;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
         horizontalInput = Input.GetAxis("Horizontal");
        transform.localPosition += Vector3.right * horizontalInput * speed * Time.deltaTime;

        if(transform.localPosition.x < xRangeMin)
        {
            transform.localPosition = new Vector3(xRangeMin, transform.localPosition.y, transform.localPosition.z); 
        }
        else if(transform.localPosition.x > xRangeMax)
        {
            transform.localPosition = new Vector3(xRangeMax, transform.localPosition.y, transform.localPosition.z);
        }
         
         //Keep player within the bounds         
        // if (transform.position.x < xRangeMin){
        //     transform.position = new Vector3(xRangeMin, transform.position.y, transform.position.z );
            
        // } else if (transform.position.x > xRangeMax){
        //     transform.position = new Vector3(xRangeMax, transform.position.y, transform.position.z);
        // } 


    

        //jump
       isJumping = Physics.Raycast(transform.position, Vector3.down, 1); //check if player is on the ground
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10f, Color.yellow);
        //check for spacebar press
         if (Input.GetKeyDown(KeyCode.Space) && !isJumping){
            Jump();
        }
        
    }
}
