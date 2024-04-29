using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_SkipCutscene : MonoBehaviour
{
    /*[SerializeField] GameObject openingCutscene;
    [SerializeField] GameObject postLevel1Cutscene;
    [SerializeField] GameObject preLevel2Cutscene;
    [SerializeField] GameObject preLevel3Cutscene;
    [SerializeField] GameObject postLevel3Cutscene;
    [SerializeField] GameObject endingCutscene;*/
    [SerializeField] TMPro.TMP_Text tip;

    int prevLevel;
    bool buttonPressed;


    void Start()
    {
        tip.gameObject.SetActive(false);
        prevLevel = GameManager.Instance.currentLevel;
        buttonPressed = false;
        switch (prevLevel)
        {
            case 0:
                //gameObject.SetActive(openingCutscene);
                break;
            case 1:
                //gameObject.SetActive(postLevel1Cutscene);
                break;
            case 2:
                //gameObject.SetActive(preLevel3Cutscene);
                break;
            case 3:
                //gameObject.SetActive(endingCutscene);
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
        {
            if (prevLevel == 0)
            {
                tip.gameObject.SetActive(true);
                tip.text = "Press Q to use your torch and scare away the monster";
                Invoke("LoadLevel1", 3);
            }
            else if (prevLevel == 1)
            {
                if (!buttonPressed)
                {
                    //gameObject.SetActive(preLevel2Cutscene);
                    buttonPressed = true;
                }
                else
                {
                    tip.gameObject.SetActive(true);
                    tip.text = "Press Q to use your headphones and block out the laughter";
                    Invoke("LoadLevel2", 3);
                }
            }
            else if (prevLevel == 2)
            {
                tip.gameObject.SetActive(true);
                tip.text = "Being near pictures might make you feel better";
                Invoke("LoadLevel3", 3);
            }
            else if (prevLevel == 3)
            {
                if(!buttonPressed)
                {
                    //gameObject.SetActive(secondCutscenePlayed);
                    buttonPressed = true;
                }
                else
                {
                    LoadMainMenu();
                }
            }
        }
    }

    private void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    private void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    private void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
