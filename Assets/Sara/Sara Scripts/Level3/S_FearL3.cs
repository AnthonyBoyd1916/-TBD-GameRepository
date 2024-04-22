using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_FearL3 : MonoBehaviour
{
    // Fear script for level 3 

    [SerializeField] CinemachineVirtualCamera m_Camera;
    [SerializeField] float defaultOrthoSize = 6;
    [SerializeField] float fearIncreaseSpeed = 0.002f; // Editable in the inspector
    [SerializeField] float fearDecreaseSpeed = 0.003f; // Editable in the inspector
    [SerializeField] Volume globalVolume;
    [SerializeField] GameObject death;

    private float fear;
    private float fearOrthoSize;
    private float vignetteMin = 0.2f;
    private float vignetteIntensity;
    private float vignetteMax = 0.7f;
    private bool insidePictureAura = false;
    Vignette vignette;

    void Start()
    {
        m_Camera.m_Lens.OrthographicSize = defaultOrthoSize;    // Sets the current Ortho size to be default

        InvokeRepeating("FearIncreaseAmbient", 1.0f, 0.1f);     // Makes the fear increase or decrease every 0.1 seconds.
        globalVolume.profile.TryGet(out vignette);

        GameManager.Instance.currentLevel = 3;

        vignette.intensity.value = vignetteMin;
        vignetteIntensity = vignetteMin;
    }

    private void Update()
    {
        if (fear > 0.2 && fear <= 0.7 && vignetteIntensity != vignetteMax)
        {
            vignette.intensity.value = fear;
        }
    }

    void FearIncreaseAmbient()
    {
        if (insidePictureAura == false) // Is the player near a picture frame?
        {
            if (fear < 1) // Makes sure that the game doesn't make fear climb too high over 1 (1 is the limit for ending the level)
            {
                if (fear > 0.5 && fearOrthoSize > 5) // Tests if the fear is high enough and the camera is not too close
                {
                    float minLerpOrthoValue = fearOrthoSize;
                    fearOrthoSize -= (defaultOrthoSize * fearIncreaseSpeed); // Changes the ortho size
                    float maxLerpOrthoValue = fearOrthoSize;
                    m_Camera.m_Lens.OrthographicSize = Mathf.Lerp(minLerpOrthoValue, maxLerpOrthoValue, 1f); // Tries to smooth out the change in ortho size
                }

                fear += fearIncreaseSpeed; // Increases the fear level
            }

            else if (fear >= 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (insidePictureAura == true) // Is the player near a picture frame?
        {
            float minLerpOrthoValue = fearOrthoSize;
            fearOrthoSize = fearOrthoSize + (defaultOrthoSize * fearDecreaseSpeed);
            if (fearOrthoSize > defaultOrthoSize)   // If fear ortho size is larger than the the starting size
            {
                fearOrthoSize = defaultOrthoSize;   // Set the fear ortho size to be the same as the starting size
            }
            float maxLerpOrthoValue = fearOrthoSize;
            m_Camera.m_Lens.OrthographicSize = Mathf.Lerp(minLerpOrthoValue, maxLerpOrthoValue, 1f);

            fear -= fearDecreaseSpeed; // Decreases the fear level
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level1")
        {
            //deathBehaviour.playerLevel = 1;
        }
        else if (collision.gameObject.tag == "Level2")
        {
            //deathBehaviour.playerLevel = 2;
        }
        else if (collision.gameObject.tag == "Level3")
        {
            //deathBehaviour.playerLevel = 3;
        }
        else if (collision.gameObject.tag == "PictureAura") // Is the collided with object tagged "Picture Aura"
        {
            insidePictureAura = true; // Set the player to be inside picture aura
        }
        else if (collision.gameObject.tag == "Death") //Made By Anthony, checks for collision with Death in-game and triggers Game Over
        {
            fear = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // Is the collided with object tagged "Picture Aura"
    {
        if (collision.gameObject.tag == "PictureAura")
        {
            insidePictureAura = false; // Set the player to not be inside picture aura
        }
    }
}
