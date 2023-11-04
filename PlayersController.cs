using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //interact with ui 

public class PlayersController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private StarManager starManagerScript;


   // Player movement 
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRangeMin = 3.5f;  
    public float xRangeMax = 8.45f;  
 
   //player jump
    public float jumpForce = 10.0f;
    public bool isJumping = false; 

    //animate jump
    public Animator playerAnim; 

    public bool allowControl = true;

    // Audio
    private AudioSource audioSource;
    public AudioClip jumpSound;





    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
       
        //Get nr of stars from StarManager
        starManagerScript = GameObject.Find("StarSpawnManager").GetComponent<StarManager>();
        scoreText.text = "Stars: 0/" + starManagerScript.nrStars;
    }

    void Jump(){
       if (!isJumping){
            //add force to the player
            isJumping = true;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetBool("Jump_b", true); 
            audioSource.PlayOneShot(jumpSound, 1.0f);
           
        } 
    }

  

    // Update is called once per frame
    void Update()
    {  
        if (allowControl == false){
            return;
        }
        
        if(allowControl){
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

            //if not jumping, set to false
            playerAnim.SetBool("Jump_b", false); 

            //jump
            isJumping = Physics.Raycast(transform.position, Vector3.down, 1); //check if player is on the ground
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10f, Color.yellow);
            
            //check for spacebar press
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping){
                Jump();
        
            }
        
        }
    }
}
