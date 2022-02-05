using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound mainTheme;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        mainTheme.source = gameObject.AddComponent<AudioSource>();
        mainTheme.source.clip = mainTheme.clip;
        mainTheme.source.loop = true;
        mainTheme.source.volume = mainTheme.volume;
    }

    void Start()
    {
        mainTheme.source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        sound.source.Play();
    }
}
