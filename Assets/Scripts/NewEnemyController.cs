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

    public float moveSpeed;

    public float rangeOfSight = 5f;

    private void Start()
    {
        if (PlayerPrefs.GetInt("continue") == 1)
        {
            SaveData data = SavingSystem.LoadData();

            Vector3 position;
            position.x = data.positionMonster[0];
            position.y = data.positionMonster[1];
            position.z = data.positionMonster[2];
            transform.position = position;
        }
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
            ai.speed = moveSpeed;
        }
        else
        {
            ai.speed = 0f; // Stop the enemy's movement if player is out of range
        }
    }
}