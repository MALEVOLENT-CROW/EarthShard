using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class FirstSelected : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameObject _firstSelectedObj;

    private void OnEnable()
    {
            _eventSystem.SetSelectedGameObject(_firstSelectedObj);        
    }

}
