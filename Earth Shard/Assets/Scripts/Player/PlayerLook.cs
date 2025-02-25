using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private float xRotation = 0.0f;

    public float xSensitvity = 30.0f;
    public float ySensitvity = 30.0f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //calculate cam vertical rotation 
        xRotation -= (mouseY * Time.deltaTime) * ySensitvity;
        xRotation = Mathf.Clamp(xRotation, -80.0f, 80.0f);

        //apply to cam transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate player horizontally
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitvity);
    }
}
