using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_VolumeImageChange : MonoBehaviour
{
    [NonSerialized] static public int volume;
    [SerializeField] Sprite[] volumeLevels;
    [SerializeField] Image image;

    private void Start()
    {
        volume = (Convert.ToInt32(GameManager.Instance.volume)) * 10;
        image.GetComponent<Image>().sprite = volumeLevels[volume];
    }

    private void Update()
    {
        image.GetComponent<Image>().sprite = volumeLevels[volume];
    }
}
