using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] MusicSounds, SfxSounds;
    public AudioSource MusicSource, SfxSource;
    private GameObject circusMusic; // For the quiet code
    private AudioSource circusMusicSource; // For the quiet code

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

    

    private void Update()
    {
        #region Sara - Stopping and Starting Clock Code
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        if (currentSceneName != "Level 1")
        {
            MusicSource.Pause();
        }
        if (currentSceneName == "Level 1")
        {
            MusicSource.UnPause();
        }
        #endregion
        #region Sara - Quietening Circus Music when listening to headphones
        if (GameManager.Instance.currentLevel == 2)
        {
            if (circusMusic == null)
            {
                circusMusic = GameObject.Find("CircusMusic");
                circusMusicSource = circusMusic.GetComponent<AudioSource>();
            }
            if (GameManager.Instance.headphonesActive == true)
            {
                circusMusicSource.volume = 0.25f;
            }
            else if (GameManager.Instance.headphonesActive == false)
            {
                circusMusicSource.volume = 1f;
            }
        }
        
        #endregion
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
