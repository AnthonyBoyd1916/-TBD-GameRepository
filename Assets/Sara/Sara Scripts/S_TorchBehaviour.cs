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
    [SerializeField] float torchRechargeTime = 15;
    [SerializeField] public  GameObject torchDetector;
    //[SerializeField] AudioClip torchWindup;

    [NonSerialized]public float torchCharge;
    SpriteRenderer spriteRenderer;
    //AudioSource audioSource;
    [NonSerialized]public bool isFlipped;

    /*[SerializeField] private InputActionReference useTorch;

    private void OnEnable()
    {
        useTorch.action.performed += OnUseitem();
    /}
    private void OnDisable()
    {
        useTorch.action.performed -= OnUseitem();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        torchCharge = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //audioSource = GetComponent<AudioSource>();

        flippedTorch.SetActive(false);
        notFlippedTorch.SetActive(false);
        torchDetector.SetActive(false);
    }

    void Update()
    {
        if (torchCharge == 0)
        {
            ChargeTorch();
        }      
    }

    void OnUseitem(/*InputAction.CallbackContext torchused*/)
    {
        isFlipped = spriteRenderer.flipY;

        if (isFlipped == true && torchCharge == 1)
        {
            FlippedTorch();
            torchDetector.SetActive(true);
        }
        else if (isFlipped == false && torchCharge == 1)
        {
            NotFlippedTorch();
            torchDetector.SetActive(true);
        }
    }

    void FlippedTorch()
    {
        flippedTorch.SetActive(true);

        Invoke("TorchNotCharged", 5f);
    }

    void NotFlippedTorch()
    {
        notFlippedTorch.SetActive(true);

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
    }
}
