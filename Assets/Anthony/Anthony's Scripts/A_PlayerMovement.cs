using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class A_PlayerMovement : MonoBehaviour
{
    private float horz;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jppower = 10f;
    [SerializeField] private float jpfalloff = 0.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject pauseMenu;
    public SpriteRenderer spriteRenderer;
    private bool onground;

    //[SerializeField] private InputActionReference movement, useTorch;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horz = Input.GetAxisRaw("Horizontal");
        //horz = movement.action.ReadValue<Vector2>();
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
            rb.gravityScale = 2f;
        }
        else if (Input.GetKeyUp(KeyCode.S) && onground == false)
        {
            rb.gravityScale = 2f;
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
        // Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
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
