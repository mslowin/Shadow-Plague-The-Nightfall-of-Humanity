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

    /// <summary>
    /// Chnaging volume.
    /// </summary>
    /// <param name="volume">float value of volume</param>
    /// <param name="audioType">Dial, FX, Msc</param>
    public void ChangeVolume (float volume, string audioType)
    {
        if (volume > 1.0f)
        {
            volume = 1.0f;
        }

        foreach (Sound s in sounds)
        {
            if (s.name.Contains(audioType))
            {
                s.source.volume = volume;
            }
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

    public void PlayNotInteruptable (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Nie znaleziono dźwięku: " + name);
            return;
        }
        
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

    public void StopSound (string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying && s.name == name)
            {
                s.source.Stop();
            }
        }
    }

    public bool isPlayingSound (string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying && s.name == name)
            {
                return true;
            }
        }
        return false;
    }
}
