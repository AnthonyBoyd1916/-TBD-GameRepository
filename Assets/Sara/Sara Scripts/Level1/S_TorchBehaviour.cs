using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class S_TorchBehaviour : MonoBehaviour
{
    [SerializeField] GameObject notFlippedTorch;
    [SerializeField] GameObject flippedTorch;
    [SerializeField] float torchRechargeTime = 7;
    [SerializeField] public  GameObject torchDetector;

    [NonSerialized]public float torchCharge;
    [NonSerialized]public bool isFlipped, torchactive;

    // Start is called before the first frame update
    void Start()
    {
        torchCharge = 1;

        flippedTorch.SetActive(false);
        notFlippedTorch.SetActive(false);
        torchDetector.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isFlipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            isFlipped = false;
        }

        if (torchCharge == 0)
        {
            ChargeTorch();
        }

        if (torchactive && isFlipped)
        {
            notFlippedTorch.gameObject.SetActive(false);
            flippedTorch.gameObject.SetActive(true);
        }
        else if (torchactive && !isFlipped)
        {
            flippedTorch.gameObject.SetActive(false);
            notFlippedTorch.gameObject.SetActive(true);
        }
    }

    void OnUseItem()
    {
        if (torchCharge == 1)
        {
            Torch();
            torchDetector.SetActive(true);
            torchactive = true;
        }
    }

    void Torch()
    {
        Invoke("TorchNotCharged", 7f);
    }

    void ChargeTorch()
    {
        torchCharge = 0.5f;
        Debug.Log("You hear a torch winding up");

        Invoke("TorchCharged", torchRechargeTime);
        AudioManager.Instance.TorchSource.Play();
        //AudioManager.Instance.TorchSource.UnPause();
    }

    void TorchCharged()
    {
        torchCharge = 1;
        Debug.Log("You no longer hear a torch winding up");
        AudioManager.Instance.TorchSource.Stop();
        //AudioManager.Instance.TorchSource.Pause();

    }

    void TorchNotCharged()
    {
        torchCharge = 0;
        flippedTorch.SetActive(false);
        notFlippedTorch.SetActive(false);
        torchDetector.SetActive(false);
        torchactive = false;
    }
}
