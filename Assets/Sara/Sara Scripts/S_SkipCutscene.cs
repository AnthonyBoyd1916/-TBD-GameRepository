using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SkipCutscene : MonoBehaviour
{
    /*[SerializeField] GameObject openingCutscene;
    [SerializeField] GameObject postLevel1Cutscene;
    [SerializeField] GameObject preLevel2Cutscene;
    [SerializeField] GameObject preLevel3Cutscene;
    [SerializeField] GameObject postLevel3Cutscene;
    [SerializeField] GameObject endingCutscene;*/

    int prevLevel;
    bool secondCutscenePlayed;


    void Start()
    {
        prevLevel = GameManager.Instance.currentLevel;
        secondCutscenePlayed = false;
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
                SceneManager.LoadScene("Level 1");
            }
            else if (prevLevel == 1)
            {
                if (!secondCutscenePlayed)
                {
                    //gameObject.SetActive(preLevel2Cutscene);
                    secondCutscenePlayed = true;
                }
                else
                {
                    SceneManager.LoadScene("Level 2");
                }
            }
            else if (prevLevel == 2)
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (prevLevel == 3)
            {
                if(!secondCutscenePlayed)
                {
                    //gameObject.SetActive(secondCutscenePlayed);
                    secondCutscenePlayed = true;
                }
                else
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }
}
