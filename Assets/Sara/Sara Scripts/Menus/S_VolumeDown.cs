using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class S_VolumeDown : MonoBehaviour
{
    Button button;
    float volumeLevel;
    [SerializeField] GameObject image;
    S_VolumeImageChange imageChange;

    private void Awake()
    {
        button = GetComponent<Button>();
        imageChange = image.GetComponent<S_VolumeImageChange>();
        
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
            Debug.Log("Decreased Volume to:" + volumeLevel);
            //int volumeLevelInt =  Convert.ToInt32(volumeLevel);
            //imageChange.volume = volumeLevelInt;
        }
    }
}
