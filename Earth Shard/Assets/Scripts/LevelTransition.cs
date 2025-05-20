using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [Header("put name of next level")]
    [SerializeField] private string level = "MainMenu";

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(level);
        }
    }
}
