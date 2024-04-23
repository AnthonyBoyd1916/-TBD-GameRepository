using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_DeathBehaviour : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject GroundFloor1; //GroundFloor2, GroundFloor3, GroundFloor4;
    //[SerializeField] GameObject GroundFloor2;
    //[SerializeField] GameObject GroundFloor3;
    //[SerializeField] GameObject GroundFloor4;
    /*[SerializeField] GameObject GroundFloor2;
    [SerializeField] GameObject GroundFloor2;
    [SerializeField] GameObject GroundFloor2;
    [SerializeField] GameObject GroundFloor2;
    [SerializeField] GameObject GroundFloor2;
    [SerializeField] GameObject GroundFloor2;
    [SerializeField] GameObject GroundFloor2;*/
    public int playerLevel;

    [SerializeField] int deathLevel;
    [SerializeField] int deathSpeed;

    private void FixedUpdate()
    {
        //Designed and tested by Sara, expanded by Anthony

        if (playerLevel == 1 && deathLevel != 1)
        {
            transform.position = GroundFloor1.transform.position;
            deathLevel = 1;
        }
        if (playerLevel == 2 && deathLevel != 2)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 3 && deathLevel != 3)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 4 && deathLevel != 4)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 5 && deathLevel != 5)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 5 && deathLevel != 5)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 6 && deathLevel != 6)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 7 && deathLevel != 7)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 8 && deathLevel != 8)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 9 && deathLevel != 9)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 10 && deathLevel != 10)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 11 && deathLevel != 11)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 12 && deathLevel != 12)
        {
            transform.position = spawnPoint.transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * deathSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Designed and tested by Sara, expanded by Anthony

        if (collision.tag == "Trigger 1")
        {
            playerLevel = 1;
        }
        else if (collision.tag == "Trigger 2")
        {
            deathLevel = 2;
        }
        else if (collision.tag == "Trigger 3")
        {
            deathLevel = 3;
        }
        else if (collision.tag == "Trigger 4")
        {
            deathLevel = 4;
        }
        else if (collision.tag == "Trigger 5")
        {
            deathLevel = 5;
        }
        else if (collision.tag == "Trigger 6")
        {
            deathLevel = 6;
        }
        else if (collision.tag == "Trigger 7")
        {
            deathLevel = 7;
        }
        else if (collision.tag == "Trigger 8")
        {
            deathLevel = 8;
        }
        else if (collision.tag == "Trigger 9")
        {
            deathLevel = 9;
        }
        else if (collision.tag == "Trigger 10")
        {
            deathLevel = 10;
        }
        else if (collision.tag == "Trigger 11")
        {
            deathLevel = 11;
        }
        else if (collision.tag == "Trigger 12")
        {
            deathLevel = 12;
        }
    }
}