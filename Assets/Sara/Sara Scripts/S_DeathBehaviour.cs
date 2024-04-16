using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_DeathBehaviour : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnPoint;
    public int playerLevel;

    [SerializeField] int deathLevel;
    [SerializeField] int deathSpeed;

    private void FixedUpdate()
    {
        if (playerLevel == 1 && deathLevel != 1)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 2 && deathLevel != 2)
        {
            transform.position = spawnPoint.transform.position;
        }
        if (playerLevel == 3 && deathLevel != 3)
        {
            transform.position = spawnPoint.transform.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * deathSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Level1")
        {
            deathLevel = 1;
        }
        else if (collision.tag == "Level2")
        {
            deathLevel = 2;
        }
        else if (collision.tag == "Level3")
        {
            deathLevel = 3;
        }
    }
}