using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] MusicSounds, SfxSounds;
    public AudioSource MusicSource, SfxSource;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Clock");
    }

    public void PlayMusic(string name)
    {

        Sound s = Array.Find(MusicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            MusicSource.clip = s.clip;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
            Sound s = Array.Find(SfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            SfxSource.PlayOneShot(s.clip);
        }
    }




}
