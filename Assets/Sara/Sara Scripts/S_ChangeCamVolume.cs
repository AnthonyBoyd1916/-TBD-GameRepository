using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ChangeCamVolume : MonoBehaviour
{
    private void Start()
    {
        AudioListener.volume = GameManager.Instance.volume;
    }
}
