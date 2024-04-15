using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_DeathBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] waypoint;
    [SerializeField] GameObject player;

    int mostRecentWp;
    int playerMostRecentWp;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        
    }
}
