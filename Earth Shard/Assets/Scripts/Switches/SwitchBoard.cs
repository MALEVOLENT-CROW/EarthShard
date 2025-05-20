using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBoard : MonoBehaviour
{
    //switches
    [Header("switch game objects")]
    [SerializeField] private Switch switch1;
    [SerializeField] private Switch switch2;
    [SerializeField] private Switch switch3;

    //gems on board on states
    [Header("gem on states")]
    [SerializeField] private GameObject onStateGem1;
    [SerializeField] private GameObject onStateGem2;
    [SerializeField] private GameObject onStateGem3;

    //gem board off states
    [Header("gem off states")]
    [SerializeField] private GameObject offStateGem1;
    [SerializeField] private GameObject offStateGem2;
    [SerializeField] private GameObject offStateGem3;

    //get door
    [Header("Door Animator")]
    [SerializeField] private Animator door;

    //all active
    private bool allActive = false;

    private void Update()
    {
        //switch 1 active
        if (switch1.active == true)
        {
            offStateGem1.SetActive(false);
            onStateGem1.SetActive(true);
        }

        //switch 2 active
        if (switch2.active == true)
        {
            offStateGem2.SetActive(false);
            onStateGem2.SetActive(true);
        }

        //switch 3 active
        if (switch3.active == true)
        {
            offStateGem3.SetActive(false);
            onStateGem3.SetActive(true);
        }

        if ((switch1.active == true && switch2.active == true && switch3.active == true) && allActive == false)
        {
            allActive = true;
            door.SetBool("IsOpen", allActive);
        }

    }
}
