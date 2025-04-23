using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents; //add or remove InteractionEvent.cs to this obj.
    public string promptMessage; //Message shown to player when looking at interactable

    public virtual string OnLook()
    {
        return promptMessage;
    }

    //this function is called from player.
    public void BaseInteract()
    {
        if(useEvents) 
            GetComponent<InteractionEvent>().onInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {
        //template fuction to be overridden by subclass
    }
}
