using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Credits : MonoBehaviour
{
    [SerializeField] GameObject teamCredits;
    [SerializeField] GameObject soundCredits;

    private void Start()
    {
        teamCredits.SetActive(true);
        soundCredits.SetActive(false);
        Invoke("SoundCredits", 3f);
    }

    void SoundCredits()
    {
        teamCredits.SetActive(false);
        soundCredits.SetActive(true);
        Invoke("LoadMainMenu", 3f);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
