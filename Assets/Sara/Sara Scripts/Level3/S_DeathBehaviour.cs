using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_DeathBehaviour : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Death Spawnpoints
    //Level1
    [SerializeField] GameObject L1West;
    [SerializeField] GameObject L1MidWest;
    [SerializeField] GameObject L1Mid;
    [SerializeField] GameObject L1East;
    //Level2
    [SerializeField] GameObject L2East;
    [SerializeField] GameObject L2West;
    //Level2b
    [SerializeField] GameObject L2b;
    //Level3West
    [SerializeField] GameObject L3WWest;
    [SerializeField] GameObject L3WEast;
    //Level3WestB
    [SerializeField] GameObject L3Wb;
    //Level3East
    [SerializeField] GameObject L3EWest;
    [SerializeField] GameObject L3EEast;
    //Level4
    [SerializeField] GameObject L4West;
    [SerializeField] GameObject L4East;

    public int playerLevel; // Set in fear script {1=L1, 2=L2, 3=L3W, 4=L3E, 5=L4, 6=L2b, 7=L3Wb}
    public string playerTiggerLoc; // Set in fear script

    [SerializeField] int deathLevel;
    [SerializeField] int deathSpeed;

    private void FixedUpdate()
    {
        if (playerLevel != deathLevel)
        {
            switch (playerTiggerLoc)
            {
                case "L1West":
                    transform.position = L1West.transform.position;
                    break;
                case "L1MidWest":
                    transform.position = L1MidWest.transform.position;
                    break;
                case "L1Mid":
                    transform.position = L1Mid.transform.position;
                    break;
                case "L1MidEast":
                    transform.position = L1MidWest.transform.position;
                    break;
                case "L1East":
                    transform.position = L1East.transform.position;
                    break;
                case "L2East":
                    transform.position = L2East.transform.position;
                    break;
                case "L2West":
                    transform.position = L2West.transform.position;
                    break;
                case "L2b":
                    transform.position = L2b.transform.position;
                    break;
                case "L3WWest":
                    transform.position = L3WWest.transform.position;
                    break;
                case "L3WEast":
                    transform.position = L3WEast.transform.position;
                    break;
                case "L3Wb":
                    transform.position = L3Wb.transform.position;
                    break;
                case "L3EWest":
                    transform.position = L3EWest.transform.position;
                    break;
                case "L3EEast":
                    transform.position = L3EEast.transform.position;
                    break;
                case "L4West":
                    transform.position = L4West.transform.position;
                    break;
                case "L4East":
                    transform.position = L4East.transform.position;
                    break;
                default:
                    break;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * deathSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "L1West":
                deathLevel = 1;
                break;
            case "L1MidWest":
                deathLevel = 1;
                break;
            case "L1Mid":
                deathLevel = 1;
                break;
            case "L1MidEast":
                deathLevel = 1;
                break;
            case "L1East":
                deathLevel = 1;
                break;
            case "L2East":
                deathLevel = 2;
                break;
            case "L2West":
                deathLevel = 2;
                break;
            case "L2b":
                deathLevel = 6;
                break;
            case "L3WWest":
                deathLevel = 3;
                break;
            case "L3WEast":
                deathLevel = 3;
                break;
            case "L3Wb":
                deathLevel = 7;
                break;
            case "L3EWest":
                deathLevel = 4;
                break;
            case "L3EEast":
                deathLevel = 4;
                break;
            case "L4West":
                deathLevel = 5;
                break;
            case "L4East":
                deathLevel = 5;
                break;
            default:
                break;
        }
    }
}