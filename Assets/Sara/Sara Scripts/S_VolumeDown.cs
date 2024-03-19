using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class S_VolumeDown : MonoBehaviour
{
    Button button;
    float volumeLevel;

    private void Start()
    {
        button = GetComponent<Button>();
        
        volumeLevel = GameManager.Instance.volume * 10;
        
        button.onClick.AddListener(VolumeDown);
    }

    void VolumeDown()
    {
        
        volumeLevel = GameManager.Instance.volume * 10;

        if (volumeLevel > 0)
        {
            volumeLevel--;;
            GameManager.Instance.volume = volumeLevel / 10;
            int volumeLevelInt =  Convert.ToInt32(volumeLevel);
            S_VolumeImageChange.volume = volumeLevelInt;
        }
    }
}
