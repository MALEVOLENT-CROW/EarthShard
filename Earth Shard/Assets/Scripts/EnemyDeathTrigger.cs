using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will open a door when the enemies added too the list are all destroyed.
public class EnemyDeathTrigger : MonoBehaviour
{
    [SerializeField] private Animator door;
    public List<GameObject> enemies;


    // Update is called once per frame
    void Update()
    {
        //removes enemy from list if dead.
        for (int i = 0; i < enemies.Count;i++)
        {
            if (enemies[i] == null)
            {
                enemies.Remove(enemies[i]);
            }
        }

        //opens door when all are dead.
        if(enemies.Count <= 0)
        {
            door.SetBool("IsOpen", true);
        }
    }
}
