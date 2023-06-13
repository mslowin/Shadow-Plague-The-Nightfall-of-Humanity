using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound i in sounds)
        {
            i.source = gameObject.AddComponent<AudioSource>();
            i.source.clip = i.clip;

            i.source.volume = i.volume;
            i.source.pitch = i.pitch;
            i.source.loop = i.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Nie znaleziono dźwięku: " + name);
            return;
        }

        StopDialogueSounds();
        
        s.source.Play();
    }

    private void StopDialogueSounds ()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying && s.name.Contains("Dial"))
            {
                s.source.Stop();
            }
        }
    }
}
