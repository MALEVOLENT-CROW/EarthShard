using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //very simple script that kill the player when collided with.
    private void OnTriggerEnter(Collider other)
    {
        Transform hitTransform = other.transform;
        if(hitTransform.CompareTag("Player"))
        {
            Debug.Log("Death Zone Trigger");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(1000);
        }
    }

    
}
