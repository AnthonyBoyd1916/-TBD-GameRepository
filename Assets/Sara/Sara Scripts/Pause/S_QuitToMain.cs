using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_QuitToMain : MonoBehaviour
{
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnQuitToMain);
    }

    void OnQuitToMain()
    {
        //Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }
}
