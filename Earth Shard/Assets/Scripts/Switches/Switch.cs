using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //states
    [SerializeField] private GameObject onState;
    [SerializeField] private GameObject offState;

    //is active bool
    public bool active = false;

    //debug name for switch
    [SerializeField] private string switchName = "Test";

    //detect when projectile enters trigger
    private void OnTriggerEnter(Collider other)
    {
        //switches the state
        if (active == false)
        {
            offState.SetActive(false);
            onState.SetActive(true);

            active = true;

            Debug.Log("switch " + switchName + " activated.");
        }
    }
}
