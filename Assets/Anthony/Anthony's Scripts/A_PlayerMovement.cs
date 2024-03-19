using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_PlayerMovement : MonoBehaviour
{
    private float horz;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jppower = 10f;
    [SerializeField] private float jpfalloff = 0.5f;
    [SerializeField] private Rigidbody2D rb;    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horz = Input.GetAxisRaw("Horizontal"); 
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jppower);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jpfalloff);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.gravityScale = 8f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = 1f;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horz * speed, rb.velocity.y);
    }
}
