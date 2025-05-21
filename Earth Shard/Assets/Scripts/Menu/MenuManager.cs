using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    //private fields
    [HideInInspector]
    public bool gamePaused = false;

    //Cam
    [SerializeField]
    private Animator camAnimator;

    //start game paused or not
    [SerializeField]
    private bool startPaused;

    //menu objects
    [Header("Menus (only applicable too scenes with a PlayerUI)")]
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject playerUI;

    //menu trans controls
    private bool credits;
    private bool levelSelect;


    private void Start()
    {
        //makes sure game time is running at start of level
        if (startPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }


    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartLevel4()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {


        if (!gamePaused)
        {
            //unlock cursor
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;

            gamePaused = true;
            pauseMenu.SetActive(true);
            //playerUI.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            //lock cursor to cam
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;

            gamePaused = false;
            pauseMenu.SetActive(false);
            //playerUI.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void LevelSelectTrans()
    {
        levelSelect = !levelSelect;
        camAnimator.SetBool("LevelSelect", levelSelect);
    }

    public void CreditsTrans()
    {
        credits = !credits;
        camAnimator.SetBool("Credits", credits);
    }

}
