using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class S_VolumeUp : MonoBehaviour
{
    Button button;
    float volumeLevel;

    private void Start()
    {
        button = GetComponent<Button>();

        volumeLevel = GameManager.Instance.volume * 10;

        button.onClick.AddListener(VolumeUp);
    }

    void VolumeUp()
    {
        volumeLevel = GameManager.Instance.volume * 10;
        if (volumeLevel < 10)
        {
            volumeLevel++;
            GameManager.Instance.volume = volumeLevel / 10;
            S_VolumeImageChange.volume = Convert.ToInt32(volumeLevel);
        }
    }
}
