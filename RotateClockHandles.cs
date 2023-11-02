using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClockHandles : MonoBehaviour
{
   // private RigidBody playerRb;
   // public GameObject turnHandle;
    public float rotationSpeedHour = 30.0f; 
    public float rotationSpeedMinute = 6.0f;
  
    public Transform hourHand;
    public Transform minuteHand;

    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>(); 
       // playerRb.AddForce()
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateHandles(hourHand, rotationSpeedHour * Time.deltaTime);
        RotateHandles(minuteHand, rotationSpeedMinute * Time.deltaTime);
    }

    void RotateHandles(Transform clockHand, float rotationSpeed)
    {   //rotate y axis 
        clockHand.Rotate(Vector3.up, rotationSpeed);
    }
}
