using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearL2 : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_Camera;
    [SerializeField] float defaultOrthoSize;
    [SerializeField] float fearIncreaseSpeed = 0.002f; // Editable in the inspector
    [SerializeField] float fearDecreaseSpeed = 0.003f; // Editable in the inspector
    [SerializeField] float clownFearIncrease = 0.1f;
    [SerializeField] float bullyFearIncrease = 0.05f;
    [SerializeField] Image vignette;

    private float fear;
    private float fearOrthoSize = 9;
    private Color vignetteColor;
    private Color fearVignetteColor;

    void Start()
    {
        m_Camera.m_Lens.OrthographicSize = defaultOrthoSize;    // Sets the current Ortho size to be default

        InvokeRepeating("FearIncreaseAmbient", 1.0f, 0.1f);     // Makes the fear increase or decrease every 0.1 seconds.
        vignetteColor = vignette.GetComponent<Image>().color;   // Gets the component colour of the vignette
    }

    private void Update()
    {
        if (fear < 0.25 && fear > 0)
        {
            float colourAlphaNumber = fear/2; // Sets it so for the first quarter of the fear meter, the opacity is only half of the fear
            fearVignetteColor.a = colourAlphaNumber;
            fearVignetteColor.r = 1f; fearVignetteColor.b = 1f; fearVignetteColor.g = colourAlphaNumber; // Sets each of the colours to 1 as there was an issue of them all turning to 0
            vignette.GetComponent<Image>().color = Color.Lerp(vignetteColor, fearVignetteColor, 0.1f); // Attempts to smooth out the opacity change
        }
        if (fear > 0.25)
        {
            float colourAlphaNumber = fear; // Sets it so that the opacity is equal to the fear level
            fearVignetteColor.a = colourAlphaNumber;
            fearVignetteColor.r = 1f; fearVignetteColor.b = 1f; fearVignetteColor.g = colourAlphaNumber; // Same as above, sets colour channels to 1
            vignette.GetComponent<Image>().color = fearVignetteColor; //Color.Lerp(vignetteColor, fearVignetteColor, 0.1f); // Same as above, tries to smooth the change
        }
        
    }

    void FearIncreaseAmbient()
    {
        if (fear < 1.2) // Makes sure that the game doesn't make fear climb too high over 1 (1 is the limit for ending the level)
        {
            if (fear > 0.5 && fearOrthoSize > 5) // Tests if the fear is high enough and the camera is not too close
            {
                float minLerpOrthoValue = fearOrthoSize;
                fearOrthoSize -= (defaultOrthoSize * fearIncreaseSpeed); // Changes the ortho size
                float maxLerpOrthoValue = fearOrthoSize;
                m_Camera.m_Lens.OrthographicSize = fearOrthoSize; // Mathf.Lerp(minLerpOrthoValue, maxLerpOrthoValue, 1f); // Tries to smooth out the change in ortho size
            }

            fear += fearIncreaseSpeed; // Increases the fear level
            Debug.Log(fear); // Delete after testing
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Clown")
        {
            fear += clownFearIncrease;
            Debug.Log("Clown Spike"); // Delete after testing
        }
        if (collision.gameObject.tag == "Bully")
        {
            fear += bullyFearIncrease;
            Debug.Log("Bully Spike"); // Delete after testing
        }
    }
}
