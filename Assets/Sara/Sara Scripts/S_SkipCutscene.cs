using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class S_SkipCutscene : MonoBehaviour
{
    /*[SerializeField] VideoPlayer openingCutscene;
    [SerializeField] VideoPlayer postLevel1Cutscene;
    [SerializeField] VideoPlayer preLevel2Cutscene;
    [SerializeField] VideoPlayer preLevel3Cutscene;*/
    [SerializeField] VideoPlayer postLevel3Cutscene;
    //[SerializeField] VideoPlayer endingCutscene;
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
                //openingCutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
                break;
            case 1:
                //gameObject.SetActive(postLevel1Cutscene);
                //postLevel1Cutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
                break;
            case 2:
                //gameObject.SetActive(preLevel3Cutscene);
                //preLevel3Cutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
                break;
            case 3:
                gameObject.SetActive(postLevel3Cutscene);
                postLevel3Cutscene.SetDirectAudioVolume(0,GameManager.Instance.volume);
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
                    //preLevel2Cutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
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
                    //gameObject.SetActive(endingCutscene);
                    //endingCutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
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
