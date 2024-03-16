using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_ResumeGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPressResume);
    }

    void OnPressResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
