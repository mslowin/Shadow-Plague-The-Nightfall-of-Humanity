using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public UnityEngine.AI.NavMeshAgent ai;
    Vector3 dest;

    //public float moveSpeed = 5f;
    public float rangeOfSight = 5f;

    private void Start()
    {
        // Get a reference to the player's transform
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        // Check if the distance to the player is within the range of sight
        if (distanceToPlayer <= rangeOfSight)
        {
            dest = target.position;
            ai.destination = dest;
            
        }
    }
}
