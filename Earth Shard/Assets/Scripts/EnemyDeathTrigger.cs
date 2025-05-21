using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathTrigger : MonoBehaviour
{
    [SerializeField] private Animator door;
    public List<GameObject> enemies;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Count;i++)
        {
            if (enemies[i] == null)
            {
                enemies.Remove(enemies[i]);
            }
        }

        if(enemies.Count <= 0)
        {
            door.SetBool("IsOpen", true);
        }
    }
}
