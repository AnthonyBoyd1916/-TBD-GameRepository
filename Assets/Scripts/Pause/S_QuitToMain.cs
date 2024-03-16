using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;

public class S_QuitToMain : MonoBehaviour
{
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPressPlay);
    }

    void OnPressPlay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuMain");
    }
}
