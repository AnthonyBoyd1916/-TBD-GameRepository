using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class S_PlayerController : MonoBehaviour
{
    [SerializeField] float jumpStregth;
    [SerializeField] float moveSpeed;

    [SerializeField] LayerMask platformLayer;
    [SerializeField] float gravScaleMultiplier = 3;
    [SerializeField] GameObject pauseMenu;

    float sidewaysADInput;
    float ladderMovement; // Needed for ladder stuff
    public bool isGrounded;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float normalGravScale;
    private bool onLadder; // Needed for ladder stuff

    PlayerInput playerInput;


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

        Debug.Log("On Ladder:" + onLadder);
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

    // Ladder stuff
    private void OnLadderMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    // Unity Input System
    private void OnJump()
    {
        rb.velocity += Vector2.up * jumpStregth;
        isGrounded = false;
    }

    // From Anthony's movement scripts
    private void OnFastFall()
    {
        rb.gravityScale = normalGravScale * gravScaleMultiplier;
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