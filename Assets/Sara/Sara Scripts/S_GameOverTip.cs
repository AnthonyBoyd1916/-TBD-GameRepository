using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_GameOverTip : MonoBehaviour
{
    int level;
    int randomNumber;
    TMP_Text text;

    private void Start()
    {
        level = GameManager.Instance.currentLevel;

        text = GetComponent<TMP_Text>();

        randomNumber = Convert.ToInt32(UnityEngine.Random.Range(0, 5));

        switch (level)
        {
            case 1:
                Level1Tip();
                break;
            case 2:
                Level2Tip();
                break;
            case 3:
                Level3Tip();
                break;
            default:
                // Have a random tip
                break;
        }
    }

    void Level1Tip()
    {
        switch (randomNumber)
        {
            case 0:
                text.SetText("Press Q to activate your torch and scare away monsters in the dark");
                break;
            case 1:
                text.SetText("Those footsteps might not be your own");
                break;
            case 2:
                text.SetText("Press W and S to go up and down stairs");
                break;
            case 3:
                text.SetText("Don't let it catch you!");
                break;
            case 4:
                text.SetText("Keep going");
                break;
            default:
                text.SetText("Fear of fear is fear of nothing");
                break;
        }
    }

    void Level2Tip()
    {
        switch (randomNumber)
        {
            case 0:
                text.SetText("Press Q to activate your headphones and block out those bullies");
                break;
            case 1:
                text.SetText("You need to collect more batteries for your headphones");
                break;
            case 2:
                text.SetText("Press W and S to go up and down ladders");
                break;
            case 3:
                text.SetText("Don't let them get you!");
                break;
            case 4:
                text.SetText("Keep going");
                break;
            default:
                text.SetText("Fear of fear is fear of nothing");
                break;
        }
    }

    void Level3Tip()
    {
        switch (randomNumber)
        {
            case 0:
                text.SetText("Being around pictures might help with your fear");
                break;
            case 1:
                text.SetText("Those footsteps aren't your own");
                break;
            case 2:
                text.SetText("Press W and S to go up and down stairs");
                break;
            case 3:
                text.SetText("Don't let Death catch you!");
                break;
            case 4:
                text.SetText("Keep going");
                break;
            default:
                text.SetText("Fear of fear is fear of nothing");
                break;
        }
    }
}
