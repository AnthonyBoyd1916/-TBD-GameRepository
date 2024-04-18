using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_VolumeImageChange : MonoBehaviour
{
    public int volume;
    float floatVolume;
    [SerializeField] Sprite[] volumeLevels;
    [SerializeField] Image image;

    private void Start()
    {
        floatVolume = (GameManager.Instance.volume) * 10;
        volume = Convert.ToInt32(floatVolume);
        image.GetComponent<Image>().sprite = volumeLevels[volume];
    }

    private void Update()
    {
        floatVolume = (GameManager.Instance.volume) * 10;
        volume = Convert.ToInt32(floatVolume);
        image.GetComponent<Image>().sprite = volumeLevels[volume];
    }
}
