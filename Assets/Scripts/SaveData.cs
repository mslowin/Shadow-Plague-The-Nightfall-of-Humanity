using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float[] position;

    public float[] positionMonster;

    public SaveData(SC_FPSController player, GameObject monster)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        positionMonster = new float[3];
        positionMonster[0] = monster.transform.position.x;
        positionMonster[1] = monster.transform.position.y;
        positionMonster[2] = monster.transform.position.z;
    }
}
