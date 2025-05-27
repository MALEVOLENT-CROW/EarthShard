using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    //opens external URL
    public void OpenWebsite(string url = "https://forms.gle/EQ9mtcrvHsbTznfE8")
    {
        Application.OpenURL(url);
    }
}
