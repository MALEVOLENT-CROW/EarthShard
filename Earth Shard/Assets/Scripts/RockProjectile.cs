using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    private Transform rockPos;
    [SerializeField] private Transform throwerPos;
    [SerializeField] private GameObject impactEffect;

    private MeshCollider rockCol;
    private Rigidbody rb;

    public bool held;

    // Start is called before the first frame update
    void Start()
    {
        throwerPos = GameObject.FindWithTag("Thrower").GetComponent<Transform>();

        rockPos = GetComponent<Transform>();
        rockCol = gameObject.GetComponent<MeshCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        if (held)
        {
            HoldRock();
        }
        else { rockCol.enabled = true; rb.useGravity = true; }
    }

    private void HoldRock()
    {
        rockCol.enabled = false;
        rb.useGravity = false;
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
