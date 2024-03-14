using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_VolumeUp : MonoBehaviour
{
    [SerializeField] Image currentVolume;
    [SerializeField] Sprite[] volumeLevels;

    Button button;
    int volumeLevel;

    private void Start()
    {
        currentVolume = GetComponent<Image>();
        button = GetComponent<Button>();

        button.onClick.AddListener(VolumeUp);
    }

    void VolumeUp()
    {
        volumeLevel = volumeLevels.Length;

        if (volumeLevel < 10)
        {
            volumeLevel++;
            currentVolume.sprite = volumeLevels[volumeLevel];
        }
    }
}
