using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class S_VolumeDown : MonoBehaviour
{
    [SerializeField] Image currentVolume;
    [SerializeField] Sprite volumeLevel0;
    [SerializeField] Sprite volumeLevel01;
    [SerializeField] Sprite volumeLevel02;
    [SerializeField] Sprite volumeLevel03;
    [SerializeField] Sprite volumeLevel04;
    [SerializeField] Sprite volumeLevel05;
    [SerializeField] Sprite volumeLevel06;
    [SerializeField] Sprite volumeLevel07;
    [SerializeField] Sprite volumeLevel08;
    [SerializeField] Sprite volumeLevel09;
    [SerializeField] Sprite volumeLevel10;

    Button button;
    float volume = 10;
    float volumeLevel;

    private void Start()
    {
        currentVolume = GetComponent<Image>();
        button = GetComponent<Button>();
        
        
        volume = GameManager.Instance.volume;

        Debug.Log(volume);

        volumeLevel = GameManager.Instance.volume * 10;
        
        button.onClick.AddListener(VolumeDown);
    }

    void VolumeDown()
    {
        Debug.Log("Hi");
        if (volumeLevel > 0)
        {
            volumeLevel--;
            Debug.Log("Whattup");
            GameManager.Instance.volume = volumeLevel / 10;
            currentVolume.sprite = volumeLevel10;
        }
    }
}
