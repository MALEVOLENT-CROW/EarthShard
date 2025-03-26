using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwitcher : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private GameObject rockThrowGO;
    [SerializeField] private GameObject groundRaiseGO;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindWithTag("Player").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //toggles between abilities
        if (inputManager.player.AbilityCycle.triggered)
        {
            if (rockThrowGO.activeSelf == true)
            {
                rockThrowGO.SetActive(!rockThrowGO.activeSelf);
                groundRaiseGO.SetActive(!groundRaiseGO.activeSelf);
            }
            else if (groundRaiseGO.activeSelf == true)
            {

                groundRaiseGO.SetActive(!groundRaiseGO.activeSelf);
                rockThrowGO.SetActive(!rockThrowGO.activeSelf);
            }
        }
    }
}
