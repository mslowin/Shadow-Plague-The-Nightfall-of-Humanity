using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolumeOptionsMenu : MonoBehaviour
{
    public Slider slider;

    private string type;

    // Update is called once per frame
    void Update()
    {
        if (slider.name.Contains("Music"))
        {
            type = "Msc";
            FindObjectOfType<AudioManager>().ChangeVolume(slider.value, type);
        }
        else if (slider.name.Contains("Effects"))
        {
            type = "FX";
            FindObjectOfType<AudioManager>().ChangeVolume(slider.value, type);
        }
        else if(slider.name.Contains("Dialogues"))
        {
            type = "Dial";
            FindObjectOfType<AudioManager>().ChangeVolume(slider.value, type);
        }
    }
}
