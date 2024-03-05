using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_TrapezeScript : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int currentWPindex = 0;
    private Rigidbody2D rb;

    [SerializeField] private float trapspeed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWPindex].transform.position, transform.position) < .1f)
        {
            currentWPindex++;
            if (currentWPindex >= waypoints.Length) { currentWPindex = 0; }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWPindex].transform.position, Time.deltaTime * trapspeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1f;
        }
    }
}
