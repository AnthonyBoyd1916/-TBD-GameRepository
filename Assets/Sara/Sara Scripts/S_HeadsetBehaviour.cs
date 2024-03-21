using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class S_HeadsetBehaviour : MonoBehaviour
{
    [SerializeField] Image batteryLevelImg;
    [SerializeField] Sprite batteryFull;
    [SerializeField] Sprite batteryHigh;
    [SerializeField] Sprite batteryMid;
    [SerializeField] Sprite batteryLow;
    [SerializeField] Sprite batteryVeryLow;
    [SerializeField] Sprite batteryDead;
    [SerializeField] float musicLength = 5f; // Change this value when we know for sure how long we want the music to play for
    [SerializeField] GameObject musicNotes;

    [NonSerialized] public bool musicPlaying = false;
    
    int batteryLevel = 5;

    private void Start()
    {
        batteryLevelImg.sprite = batteryFull;
        batteryLevel = 5;

        musicNotes.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) == true)
        {
            OnUseItem();
        }
    }

    void OnUseItem()
    {
        if (batteryLevel != 0 && musicPlaying == false)
        {
            batteryLevel--;

            musicPlaying = true;
            musicNotes.SetActive(true);
            Invoke("MusicStop", musicLength); // Change this to be equal to the length of the audio clip or something
            Debug.Log("You hear some music playing");
            
            switch (batteryLevel)
            {
                case 4:
                    batteryLevelImg.sprite = batteryHigh;
                    break;
                case 3:
                    batteryLevelImg.sprite = batteryMid;
                    break;
                case 2: 
                    batteryLevelImg.sprite = batteryLow;
                    break;
                case 1: 
                    batteryLevelImg.sprite = batteryVeryLow;
                    break;
                case 0:
                    batteryLevelImg.sprite = batteryDead;
                    break;
                default:
                    batteryLevelImg = null;
                    break;
            }
        }
    }

    private void MusicStop()
    {
        musicPlaying = false;
        musicNotes.SetActive(false);
        Debug.Log("You no longer hear music");
    }
}
