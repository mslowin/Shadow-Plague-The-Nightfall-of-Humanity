using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;
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
            // Calculate the direction towards the player
            Vector3 direction = target.position - transform.position;

            // Check if the distance to the player is greater than the stopping distance
            if (direction.magnitude > stoppingDistance)
            {
                // Normalize the direction vector to have a magnitude of 1
                direction.Normalize();

                // Move towards the player
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    }
}
