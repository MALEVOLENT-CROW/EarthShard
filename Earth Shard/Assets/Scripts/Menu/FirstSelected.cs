using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class FirstSelected : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameObject _firstSelectedObj;

    //sets the first selected button. this was for controller support.
    //this stops if the player switches too mouse and keyboard from controller.
    private void OnEnable()
    {
            _eventSystem.SetSelectedGameObject(_firstSelectedObj);        
    }

}
