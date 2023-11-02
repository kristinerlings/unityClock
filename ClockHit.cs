using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHit : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == PLAYER_TAG)
        {
            Destroy(other.gameObject);
        }
    }
}
