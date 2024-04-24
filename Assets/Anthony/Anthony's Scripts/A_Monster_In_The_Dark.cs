using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Monster_In_The_Dark : MonoBehaviour
{
    [SerializeField] private float timer = 10f;
    private float chargespeed = 1f;
    private float randomizedtimer, standintimer = 500f;
    [SerializeField] private float inputspeed;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform IdleSpawnPos;
    [SerializeField] private Transform RightSpawnPos;
    [SerializeField] private Transform LeftSpawnPos;
    private bool monsteractive = false, controltimer = true, torchlightflashed = false, monsterinlevel = false;

    
    //============================================================================================
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - 0.01f;
        //---------------Manages Timer according to whether the monster is active---------------//
        if (monsteractive == false) 
        {
            NonActiveTimer();
        }
        else if ( monsteractive == true && controltimer == true)
        {
            SetRandomTimer();
            controltimer = false;
        }
        //---------------Manages Monster Entering Level---------------//
        if (timer > 0f && monsteractive == true)
        {
            transform.position = IdleSpawnPos.position;
            chargespeed = 0f;
        }
        if (timer == 0f && monsteractive == true)
        {
            transform.position = RightSpawnPos.position;
            monsterinlevel = true;
            SetCooldown();
        }
        //---------------Manages Monster Follow and being Flashed---------------//
        if (monsterinlevel == true && torchlightflashed == false)
        {
            chargespeed = inputspeed;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * chargespeed);           
        }
        else if (monsterinlevel == true && torchlightflashed == true)
        {
            transform.position = IdleSpawnPos.position;
            chargespeed = 0f;
            monsterinlevel = false;
            controltimer = true;
        }
    }

    void NonActiveTimer()
    {
        timer = standintimer;
    }
    void SetCooldown()
    {
        monsteractive = false;        
    }
    void SetRandomTimer()
    {
        randomizedtimer = Random.Range(5f, 15f);
        timer = randomizedtimer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Flashlight")
        {
            torchlightflashed = true;
        }
    }
}
