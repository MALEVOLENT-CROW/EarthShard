using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void OpenWebsite(string url = "https://forms.gle/EQ9mtcrvHsbTznfE8")
    {
        Application.OpenURL(url);
    }
}
