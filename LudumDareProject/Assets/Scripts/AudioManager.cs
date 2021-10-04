using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void resetSounds()
    {
        foreach (Sounds s in sounds)
        {
            this.Stop(s.name);
        }
    }
}
