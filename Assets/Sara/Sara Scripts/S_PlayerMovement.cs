using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpStregth;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform groundCheckDimensions;
    [SerializeField] LayerMask platformLayer;
    [SerializeField] float gravScaleMultiplier = 3;
    [SerializeField] GameObject pauseMenu;

    float sidewaysADInput;
    public bool isGrounded;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float normalGravScale;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normalGravScale = rb.gravityScale;
        Time.timeScale = 1f;
    }

    void Update()
    {
        //CheckForGround();
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = normalGravScale;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(sidewaysADInput * moveSpeed, rb.velocity.y);
    }

    // Uses Unity Input System
    private void OnMovement(InputValue axis)
    {
        sidewaysADInput = axis.Get<float>();
    }

    // Unity Input System
    private void OnJump()
    {
        if (IsGrounded())
        {
            rb.velocity += Vector2.up * jumpStregth;
            isGrounded = false;
        }
    }

    // From Anthony's movement scripts
    private void OnFastFall()
    {
        if (!IsGrounded())
        {
            rb.gravityScale = normalGravScale * gravScaleMultiplier;
        }
    }

    private void OnPause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    // From Oran's movement script
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckDimensions.position, 0.2f, platformLayer);
    }
}
