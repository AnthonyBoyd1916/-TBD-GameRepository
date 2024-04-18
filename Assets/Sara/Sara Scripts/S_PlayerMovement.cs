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
    Vector2 movement;
    bool onLadder;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    PlayerInput playerInput;
    float normalGravScale;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normalGravScale = rb.gravityScale;
        Time.timeScale = 1f;
        playerInput = GetComponent<PlayerInput>();
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
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.gravityScale = normalGravScale;
        }
    }

    private void FixedUpdate()
    {
        if (!onLadder)
        {
            rb.velocity = new Vector2(sidewaysADInput * moveSpeed, rb.velocity.y);
        }

        else if (onLadder)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // Uses Unity Input System
    private void OnMovement(InputValue axis)
    {
        sidewaysADInput = axis.Get<float>();
    }

    private void OnLadderMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            onLadder = true;
            rb.isKinematic = true;
            playerInput.SwitchCurrentActionMap("InLadder");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            onLadder = false;
            rb.isKinematic = false;
            playerInput.SwitchCurrentActionMap("InGame");
        }
    }
}
