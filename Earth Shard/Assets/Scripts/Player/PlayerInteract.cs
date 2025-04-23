using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private LayerMask mask;
    //private PlayerUI playerUI;
    private InputManager inputManager;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        //playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerUI.UpdateText(string.Empty);

        //create ray at centre of cam that shoots forward
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitinfo; //stores collision information.
        if(Physics.Raycast(ray, out hitinfo, distance, mask))
        {
            if(hitinfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitinfo.collider.GetComponent<Interactable>();
                //playerUI.UpdateText(interactable.promptMessage);
                if(inputManager.player.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
