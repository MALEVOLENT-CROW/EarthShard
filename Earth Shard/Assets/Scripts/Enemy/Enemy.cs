using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //private fields
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnowPos;

    //getters
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }


    [Header("Navigation")]
    public Path path;

    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    [Header("Weapon Values")]
    public Transform firePoint;
    [Range(0.1f, 10f)]
    public float fireRate;
    public float bulletVelocity = 40f;

    //just for debugging!
    [SerializeField] private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        stateMachine.Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if(player != null)
        {
            //check if player is in sight distance and at a viewable angle
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if(angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if(hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.magenta);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
