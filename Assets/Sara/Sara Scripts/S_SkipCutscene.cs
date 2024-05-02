using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class S_SkipCutscene : MonoBehaviour
{
    [SerializeField] VideoPlayer openingCutscene;
    [SerializeField] VideoPlayer preLevel2Cutscene;
    [SerializeField] VideoPlayer preLevel3Cutscene;
    [SerializeField] VideoPlayer postLevel3Cutscene;
    [SerializeField] VideoPlayer endingCutscene;
    [SerializeField] TMPro.TMP_Text tip;
    [SerializeField] GameObject tipBg;

    int prevLevel;

    void Start()
    {
        tip.gameObject.SetActive(false);
        tipBg.SetActive(false);
        prevLevel = GameManager.Instance.currentLevel;
        switch (prevLevel)
        {
            case 0:
                openingCutscene.gameObject.SetActive(true);
                openingCutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
                Invoke("Tips", 25f);
                break;
            case 1:
                preLevel2Cutscene.gameObject.SetActive(true);
                preLevel2Cutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
                Invoke("Tips", 20f);
                break;
            case 2:
                preLevel3Cutscene.gameObject.SetActive(true);
                preLevel3Cutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
                Invoke("Tips", 22f);
                break;
            case 3:
                postLevel3Cutscene.gameObject.SetActive(true);
                postLevel3Cutscene.SetDirectAudioVolume(0,GameManager.Instance.volume);
                Invoke("PlayEndingCutscene", 23f);
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
        {
            if (prevLevel == 0)
            {
                CancelInvoke("Tips");
                Tips();
            }
            else if (prevLevel == 1)
            {
                CancelInvoke("Tips");
                Tips();
            }
            else if (prevLevel == 2)
            {
                CancelInvoke("Tips");
                Tips();
            }
            else if (prevLevel == 3)
            {
                if (endingCutscene.gameObject.activeInHierarchy == false)
                {
                    CancelInvoke("PlayEndingCutscene");
                    postLevel3Cutscene.gameObject.SetActive(false);
                    endingCutscene.gameObject.SetActive(true);
                    endingCutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
                    Invoke("LoadCredits", 31f);
                }
                else if (endingCutscene.gameObject.activeInHierarchy == true)
                {
                    CancelInvoke("LoadCredits");
                    LoadMainMenu();
                }
            }
        }
    }

    private void Tips()
    {
        tipBg.SetActive(true);
        switch (prevLevel)
        {
            case 0:
                tip.gameObject.SetActive(true);
                tip.text = "Press Q to use your torch and scare away the monster";
                Invoke("LoadLevel1", 3);
                break;
            case 1:
                tip.gameObject.SetActive(true);
                tip.text = "Press Q to use your headphones and block out the laughter";
                Invoke("LoadLevel2", 3);
                break;
            case 2:
                tip.gameObject.SetActive(true);
                tip.text = "Being near pictures might make you feel better";
                Invoke("LoadLevel3", 3);
                break;
            default:
                tip.gameObject.SetActive(true);
                tip.text = "Something has gone quite wrong";
                break;
        }
    }

    private void PlayEndingCutscene()
    {
        postLevel3Cutscene.gameObject.SetActive(false);
        endingCutscene.gameObject.SetActive(true);
        endingCutscene.SetDirectAudioVolume(0, GameManager.Instance.volume);
        Invoke("LoadMainMenu", 31f);
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

    private void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
