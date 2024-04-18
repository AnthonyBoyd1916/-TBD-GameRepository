using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SkipCutscene : MonoBehaviour
{
    int prevLevel;

    void Start()
    {
        prevLevel = GameManager.Instance.currentLevel;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
        {
            if (prevLevel == 1)
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (prevLevel == 2)
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (prevLevel == 3)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
