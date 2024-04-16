using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class S_FearL1 : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_Camera;
    float defaultOrthoSize = 6;
    [SerializeField] float fearIncreaseSpeed = 0.002f; // Editable in the inspector
    [SerializeField] float fearDecreaseAmount = 0.002f; // Editable in the inspector
    [SerializeField] Volume globalVolume;

    private float fear;
    private float fearOrthoSize;
    private float vignetteMin = 0.2f;
    private float vignetteIntensity;
    private float vignetteMax = 0.7f;
    S_TorchBehaviour torchBehaviour;
    Vignette vignette;

    void Start()
    {
        m_Camera.m_Lens.OrthographicSize = defaultOrthoSize;    // Sets the current Ortho size to be default
        InvokeRepeating("FearIncreaseAmbient", 1.0f, 0.1f);     // Makes the fear increase or decrease every 0.1 seconds.

        globalVolume.profile.TryGet(out vignette);
        

        torchBehaviour = GetComponent<S_TorchBehaviour>(); // Gets the a reference to the script

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
        if (fear < 1.2 && torchBehaviour.torchDetector.activeInHierarchy == false) // Makes sure that the game doesn't make fear climb too high over 1 (1 is the limit for ending the level)
        {
            if (fear > 0.5 && fearOrthoSize > 5) // Tests if the fear is high enough and the camera is not too close
            {
                fearOrthoSize -= (defaultOrthoSize * fearIncreaseSpeed); // Changes the ortho size
                m_Camera.m_Lens.OrthographicSize = fearOrthoSize; // Mathf.Lerp(minLerpOrthoValue, maxLerpOrthoValue, 1f); // Tries to smooth out the change in ortho size
            }

            fear += fearIncreaseSpeed; // Increases the fear level
            Debug.Log(fear); // Delete after testing
        }

        else if (fear < 1.2 && torchBehaviour.torchDetector.activeInHierarchy == true)
        {
            Debug.Log(fear);

            fear -= fearDecreaseAmount;

            if (fearOrthoSize < defaultOrthoSize) // Tests if the camera is below default ortho size
            {
                fearOrthoSize += ((defaultOrthoSize * fearIncreaseSpeed) * 2); // Changes the ortho size
                m_Camera.m_Lens.OrthographicSize = fearOrthoSize; // Tries to smooth out the change in ortho size
            }

            Debug.Log(fear);
        }

        else if (fear > 0 && fear < 0.5)
        {

            if (fearOrthoSize < defaultOrthoSize) // Tests if the camera is below default ortho size
            {
                fearOrthoSize += ((defaultOrthoSize * fearIncreaseSpeed) * 2); // Changes the ortho size
                m_Camera.m_Lens.OrthographicSize = fearOrthoSize; // Tries to smooth out the change in ortho size
            }
        }
    }
}
