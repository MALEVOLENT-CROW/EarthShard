using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    private Transform rockPos;
    [SerializeField] private Transform throwerPos;
    [SerializeField] private GameObject impactEffect;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (!held)
        {
            GameObject impactGO = Instantiate(impactEffect, transform.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            Destroy(impactGO, 2f);

            Destroy(gameObject);
        }
    }
}
