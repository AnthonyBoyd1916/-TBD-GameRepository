using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BullyBehaviour : MonoBehaviour
{
    [SerializeField] float bullySpeed = 4f; // Editable in inspector
    [SerializeField] GameObject[] waypoints;

    private Vector3 originalPosition;
    private Vector2 playerPosition;
    private bool playerInRange;
    private int currentWaypointIndex = 0;

    void Start()
    {
        originalPosition = transform.position; // Sets the original position of the NPC so they know where they were originally
    }

    private void FixedUpdate()
    {
        if (playerInRange == true) // Is player in their range?
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, Time.fixedDeltaTime * bullySpeed); // Moves towards the player at full speed
        }
        if (playerInRange == false) // Is player not in their range AND the clown isn't at their orignial position
        {
            //transform.position = Vector2.MoveTowards(this.transform.position, originalPosition, Time.fixedDeltaTime * (bullySpeed / 2)); // Moves back to their original spot at half speed
            transform.position = Vector2.MoveTowards(this.transform.position, waypoints[currentWaypointIndex].transform.position, Time.fixedDeltaTime * (bullySpeed / 2));
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // Is the collider who entered the trigger tagged "Player"?
        {
            playerInRange = true; // Set bool to true
            playerPosition = collision.transform.position; // Save the position of the player so the bully can rush their position
        }

        else if (collision.gameObject.tag == "Waypoint")
        {
            if (currentWaypointIndex == 0)
            {
                currentWaypointIndex = 1;
            }
            else if (currentWaypointIndex == 1)
            {
                currentWaypointIndex = 0;
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // Is the collider who entered the trigger tagged "Player"?
        {
            playerInRange = true; // Set bool to true
            playerPosition = collision.transform.position; // Save the position of the player so the bully can rush their position
        }

        else if (collision.gameObject.tag == "Waypoint")
        {
            if (currentWaypointIndex == 0)
            {
                currentWaypointIndex = 1;
            }
            else if (currentWaypointIndex == 1)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // Is the collider who exited the trigger tagged "Player"?
        {
            playerInRange = false; // Set bool to false
        }
    }
}
