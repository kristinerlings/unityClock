using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.SetActive(false);      
        }
    }
}
