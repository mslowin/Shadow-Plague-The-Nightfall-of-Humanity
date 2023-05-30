using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyController : MonoBehaviour
{
    /// <summary>
    /// Players transform.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Monsters AI.
    /// </summary>
    public NavMeshAgent ai;

    /// <summary>
    /// AI's destination.
    /// </summary>
    Vector3 dest;

    //public float moveSpeed = 5f;
    public float rangeOfSight = 5f;

    private void Start()
    {
        // Get a reference to the player's transform
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the distance to the player is within the range of sight
        if (distanceToPlayer <= rangeOfSight)
        {
            dest = player.position;
            ai.destination = dest;

        }
    }
}