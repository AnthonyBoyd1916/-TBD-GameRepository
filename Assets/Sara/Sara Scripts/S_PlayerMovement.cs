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
    private Vector2 ladderMovement;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private float normalGravScale;
    private bool onLadder;

    private Animator animator;


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
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = normalGravScale;
        }

        //if (rb.velocity.x != 0f)
        //{
        //    animator.SetBool("IsMoving", true);
        //}
        //else
        //{
        //    animator.SetBool("IsMoving", false);
        //}

        //if (!IsGrounded())
        //{
        //    animator.SetBool("IsJumping", true);
        //}
        //else
        //{
        //    animator.SetBool("IsJumping", false);
        //}
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(sidewaysADInput * moveSpeed, rb.velocity.y);
        if (!onLadder) // If not on ladder, move with the sideways input
        {
            rb.velocity = new Vector2(sidewaysADInput * moveSpeed, rb.velocity.y);
        }
        else if (onLadder) // If on ladder, move with the input from the ladder
        {
            rb.MovePosition(rb.position + ladderMovement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // Uses Unity Input System
    private void OnMovement(InputValue axis)
    {
        sidewaysADInput = axis.Get<float>();
    }

    private void OnLadderMovement(InputValue value)
    {
        ladderMovement = value.Get<Vector2>();
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

    // Needed for ladder stuff
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            onLadder = true;
            rb.isKinematic = true;
            playerInput.SwitchCurrentActionMap("InLadder");
        }
    }

    // Needed for ladder stuff
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
