using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwitcher : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private GameObject rockThrowGO;
    [SerializeField] private GameObject groundRaiseGO;

    [SerializeField] private bool lockSwitching = false;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindWithTag("Player").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if both game objects are active to allow switching

        //toggles between abilities
        if(inputManager.player.AbilityCycle.triggered)
        {
            //checks if ability switching is enabled
            if(lockSwitching == false)
            {
                if(rockThrowGO.activeSelf == true)
                {
                    rockThrowGO.SetActive(!rockThrowGO.activeSelf);
                    groundRaiseGO.SetActive(!groundRaiseGO.activeSelf);
                }
                else if(groundRaiseGO.activeSelf == true)
                {

                    groundRaiseGO.SetActive(!groundRaiseGO.activeSelf);
                    rockThrowGO.SetActive(!rockThrowGO.activeSelf);
                }
            }
            else
            {
                Debug.LogWarning("Ability switching is disabled!");
            }
        }
    }
}
