using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_Play : MonoBehaviour
{
    Button button;

    private void Start()
    {
        GameManager.Instance.currentLevel = 0;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPressPlay);
    }

    void OnPressPlay()
    {
        SceneManager.LoadScene("InterlevelCutscenes");
    }
}
