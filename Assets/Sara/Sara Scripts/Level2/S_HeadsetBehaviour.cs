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

    int batteryLevel;
    //int spareBatteries = 0;

    private void Start()
    {
        batteryLevelImg.sprite = batteryFull;
        batteryLevel = 0;

        musicNotes.SetActive(false);
    }

    void OnUseItem()
    {
        //if (batteryLevel <= 2 && spareBatteries >= 1)
        //{
        //    spareBatteries--;
        //    batteryLevel += 3;
        //    ChangeBatteryImage();
        //}
        if (batteryLevel != 0 && musicPlaying == false)
        {
            batteryLevel--;

            musicPlaying = true;// For use within this script
            musicNotes.SetActive(true); // To enable the animated object to show and play looping animation
            GameManager.Instance.headphonesActive = true; // To allow clowns and bullies to ignore the player
            Invoke("MusicStop", musicLength); // Change this to be equal to the length of the audio clip or something
            Debug.Log("You hear some music playing");
            ChangeBatteryImage();
        }
    }

    private void MusicStop()
    {
        musicPlaying = false;
        musicNotes.SetActive(false);
        GameManager.Instance.headphonesActive = false;
        Debug.Log("You no longer hear music");
    }

    private void ChangeBatteryImage()
    {
        switch (batteryLevel)
        {
            case 5:
                batteryLevelImg.sprite = batteryFull;
                break;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Battery" && batteryLevel != 5)
        {
            batteryLevel = 5;
            ChangeBatteryImage();
            Destroy(collision.gameObject);
        }
    }
}
