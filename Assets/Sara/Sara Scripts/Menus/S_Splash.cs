using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMainMenu", 3f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadMainMenu();
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Level 3");
        }
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
