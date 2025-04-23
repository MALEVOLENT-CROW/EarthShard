using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] private GameObject door;
    private bool doorOpen;

    //overriden interaction code goes in here
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen",doorOpen);
    }
}
