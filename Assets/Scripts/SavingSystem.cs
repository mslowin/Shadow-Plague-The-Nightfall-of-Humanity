using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine.UI;

public static class SavingSystem
{
    public static void SaveGame(SC_FPSController player, GameObject monster, TMP_Text batteriesNumberText, Image batteryBar)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(player, monster, batteriesNumberText, batteryBar);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/data.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }

    }
}
