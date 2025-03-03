using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    private Transform rockPos;
    [SerializeField] private Transform throwerPos;

    public bool held;

    // Start is called before the first frame update
    void Start()
    {
        rockPos = GetComponent<Transform>();
        throwerPos = GameObject.FindWithTag("Thrower").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        if (held)
        {
            HoldRock();
        }
    }

    private void HoldRock()
    {
        rockPos.position = throwerPos.position;
        rockPos.rotation = throwerPos.rotation;
    }
}
