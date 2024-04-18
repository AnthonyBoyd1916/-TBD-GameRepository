using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_Restart : MonoBehaviour
{
    Button button;

    int level;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPressRestart);

        level = GameManager.Instance.currentLevel;
    }

    void OnPressRestart()
    {
        if (level == 1)
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Level 3");
        }
        else
        {
            Debug.Log("Something is wrong");
        }
    }
}
