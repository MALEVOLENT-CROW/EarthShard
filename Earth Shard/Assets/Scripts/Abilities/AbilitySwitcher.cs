using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwitcher : MonoBehaviour
{
    private InputManager inputManager;
    [Header("Game Objects")]
    [SerializeField] private GameObject rockThrowGO;
    [SerializeField] private GameObject groundRaiseGO;

    [Header("Crosshair UI")]
    [SerializeField] private GameObject rockThrowUI;
    [SerializeField] private GameObject groundRaiseUI;

    [Header("Other")]
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
                    //abilities
                    rockThrowGO.SetActive(!rockThrowGO.activeSelf);
                    groundRaiseGO.SetActive(!groundRaiseGO.activeSelf);

                    //UI
                    rockThrowUI.SetActive(!rockThrowUI.activeSelf);
                    groundRaiseUI.SetActive(!groundRaiseUI.activeSelf);
                }
                else if(groundRaiseGO.activeSelf == true)
                {
                    //abilities
                    groundRaiseGO.SetActive(!groundRaiseGO.activeSelf);
                    rockThrowGO.SetActive(!rockThrowGO.activeSelf);

                    //UI
                    rockThrowUI.SetActive(!rockThrowUI.activeSelf);
                    groundRaiseUI.SetActive(!groundRaiseUI.activeSelf);
                }
            }
            else
            {
                Debug.LogWarning("Ability switching is disabled!");
            }
        }
    }
}
