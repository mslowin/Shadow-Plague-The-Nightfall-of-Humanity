using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTrigger : MonoBehaviour
{
    /// <summary>
    /// Monster controller.
    /// </summary>
    public NewEnemyController monster;

    /// <summary>
    /// The trigger collider.
    /// </summary>
    public Collider collision;

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            monster.moveSpeed /= 2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            monster.moveSpeed *= 2f;
        }

    }
}
