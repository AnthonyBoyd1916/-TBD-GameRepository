using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_VolumeSlider : MonoBehaviour
{
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = GameManager.Instance.volume;
    }

    private void Update()
    {
        GameManager.Instance.volume = slider.value;
    }
}
