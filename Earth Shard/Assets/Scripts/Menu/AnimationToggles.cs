using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToggles : MonoBehaviour
{
    //menus
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject credits;

    public void ToggleMainMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
    }
    public void ToggleLevelSelect()
    {
        levelSelect.SetActive(!levelSelect.activeSelf);
    }
    public void ToggleCredits()
    {
        credits.SetActive(!credits.activeSelf);
    }
}
