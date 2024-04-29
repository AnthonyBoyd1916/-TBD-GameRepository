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
    [SerializeField] float torchRechargeTime = 10;
    [SerializeField] public  GameObject torchDetector;

    [NonSerialized]public float torchCharge;
    SpriteRenderer spriteRenderer;
    [NonSerialized]public bool isFlipped, torchactive;

    // Start is called before the first frame update
    void Start()
    {
        torchCharge = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();

        flippedTorch.SetActive(false);
        notFlippedTorch.SetActive(false);
        torchDetector.SetActive(false);
    }

    void Update()
    {
        isFlipped = this.spriteRenderer.flipX;

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
        isFlipped = spriteRenderer.flipX;

        if (isFlipped == true && torchCharge == 1)
        {
            Torch();
            torchDetector.SetActive(true);
            torchactive = true;
        }
    }

    void Torch()
    {
        Invoke("TorchNotCharged", 5f);
    }

    void ChargeTorch()
    {
        //audioSource.PlayOneShot(torchWindup);
        torchCharge = 0.5f;
        Debug.Log("You hear a torch winding up");

        Invoke("TorchCharged", torchRechargeTime);
    }

    void TorchCharged()
    {
        torchCharge = 1;
        Debug.Log("You no longer hear a torch winding up");
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
