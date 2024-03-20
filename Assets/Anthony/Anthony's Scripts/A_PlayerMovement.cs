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
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public SpriteRenderer spriteRenderer;
    private bool onground;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horz = Input.GetAxisRaw("Horizontal"); 
        //Jump Calculations
        if (Input.GetKeyDown(KeyCode.Space) && onground == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jppower);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jpfalloff);
        }
        //Fast Fall
        if (Input.GetKeyDown(KeyCode.S) && onground == false)
        {
            rb.gravityScale = 8f;
        }
        if (Input.GetKeyUp(KeyCode.S) && onground == true)
        {
            rb.gravityScale = 1f;
        }
        //Sprite Flip
        if (horz > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horz < 0f)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horz * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onground = false;
        }
    }
    /*private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }*/
}
