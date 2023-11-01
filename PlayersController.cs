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


    //run forward
    private Vector3 initialPosition;
    private float angle = 0.0f;

    public float forwardSpeed = 1.0f;
    public float radius = 5.0f; //radius of the circle
     




    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; //run forward 
        
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
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

         //Keep player within the bounds 
        if (transform.position.x < xRangeMin){
            transform.position = new Vector3(xRangeMin, transform.position.y, transform.position.z);
        } else if (transform.position.x > xRangeMax){
            transform.position = new Vector3(xRangeMax, transform.position.y, transform.position.z);
        } 

        //run forward
        // Calculate the new position along the circular path
        angle += forwardSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        Vector3 newPosition = initialPosition + new Vector3(x, 0, z);

        // Move the player to the new position
        transform.position = newPosition;


        //jump
       isJumping = Physics.Raycast(transform.position, Vector3.down, 0.1f); //check if player is on the ground
        //check for spacebar press
         if (Input.GetKeyDown(KeyCode.Space) && !isJumping){
            Jump();
        }
        
    }
}
