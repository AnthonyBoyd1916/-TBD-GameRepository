using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_DeathBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] waypoint;
    [SerializeField] GameObject player;

    int waypointIndex;
    int waypointIndexTesting;
    float distance;
    float smallestDistance;

    private void Start()
    {
        waypointIndex = 0;
    }

    private void FixedUpdate()
    {
        FindPlayer();
        // transform.position = waypoint[waypointIndex].transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, waypoint[waypointIndex].transform.position, Time.fixedDeltaTime);
    }

    void FindPlayer()
    {
        waypointIndexTesting = 0;
        //distance = Vector2.Distance(waypoint[0].transform.position, player.transform.position);
        //smallestDistance = distance;
        //distance = Vector2.Distance(waypoint[1].transform.position, player.transform.position);

        //if (distance < smallestDistance)
        //{
        //    smallestDistance = distance;
        //    waypointIndex = 1;
        //}
        //else
        //{
        //    waypointIndex = 0;
        //}

        //distance = Vector2.Distance(waypoint[2].transform.position, player.transform.position);

        //if (distance < smallestDistance)
        //{
        //    smallestDistance = distance;
        //    waypointIndex = 2;
        //}

        //distance = Vector2.Distance(waypoint[3].transform.position, player.transform.position);

        //if(distance < smallestDistance)
        //{
        //    smallestDistance = distance;
        //    waypointIndex = 3;
        //}

        while (waypointIndexTesting < waypoint.Length)
        {
            distance = Vector2.Distance(waypoint[waypointIndexTesting].transform.position, player.transform.position);
            smallestDistance = distance;

            if (waypointIndexTesting + 1 <= waypoint.Length)
            {
                distance = Vector2.Distance(waypoint[waypointIndexTesting + 1].transform.position, player.transform.position);
            }

            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                waypointIndex = waypointIndexTesting;
            }

            waypointIndex++;
        }
    }
}
