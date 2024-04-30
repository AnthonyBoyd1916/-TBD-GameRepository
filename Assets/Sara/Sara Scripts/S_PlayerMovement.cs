using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    private Vector2 ladderMovement, movement;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private float normalGravScale;
    private bool onLadder;

    private Animator animator; // Oran's and Anthony's Animator Code

    private float walkIntervalTimer;
    public float walkInterval = 0.25f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normalGravScale = rb.gravityScale;
        Time.timeScale = 1f;
        playerInput = GetComponent<PlayerInput>();

        animator = GetComponent<Animator>(); // Needed for Oran's and Anthony's Animator code
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

        #region Oran's Code
        /*if (rb.velocity.x != 0f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (!IsGrounded())
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }*/
        #endregion
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(sidewaysADInput * moveSpeed, rb.velocity.y);
        if (!onLadder) // If not on ladder, move with the sideways input
        {
            rb.velocity = new Vector2(sidewaysADInput * moveSpeed, rb.velocity.y);
            if (rb.velocity.x > 0.05f || rb.velocity.x < -0.05f)
            {
                WalkAudio(); // interval function to play footsteps
            }
            
        }
        else if (onLadder) // If on ladder, move with the input from the ladder
        {
            rb.MovePosition(rb.position + ladderMovement * moveSpeed * Time.fixedDeltaTime);
        }
        #region Anthony's Animator
        movement = rb.velocity;

        if (movement.x != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetBool("Moving", true);
            if (movement.x < 0) { animator.SetBool("Facing Right", false); }
            else if (movement.x > 0) { animator.SetBool("Facing Right", true); }

            if (isGrounded == true)
            {
                animator.SetBool("OnGround", true);
            }
            else
            {
                animator.SetBool("OnGround", false);
            }
        }
        else
        {
            animator.SetBool("Moving", false);
            if (movement.x < 0) { animator.SetBool("Facing Right", false); }
            else if (movement.x > 0) { animator.SetBool("Facing Right", true); }
            if (isGrounded == true)
            {
                animator.SetBool("OnGround", true);
            }
            else
            {
                animator.SetBool("OnGround", false);
            }
        }
        #endregion
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
        if (!pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else if (pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }

    // From Oran's movement script
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckDimensions.position, 0.2f, platformLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndLevel")
        {
            SceneManager.LoadScene("InterlevelCutscenes");
        }
    }

    //Audio - footstep interval
    private void WalkAudio()
    {
        walkIntervalTimer += Time.deltaTime;
        if(walkIntervalTimer>walkInterval)
        {
            walkIntervalTimer = 0;
            Debug.Log(" play a walk footstep ");
            AudioManager.Instance.PlaySFX("Walk");
        }
    }

    // Needed for ladder stuff
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            spriteRenderer.sortingOrder = -1;
            onLadder = true;
            rb.isKinematic = true;
            playerInput.SwitchCurrentActionMap("InLadder");
        }
        else if (collision.tag == "Stairs")
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
            spriteRenderer.sortingOrder = 2;
            onLadder = false;
            rb.isKinematic = false;
            playerInput.SwitchCurrentActionMap("InGame");
        }
        else if (collision.tag == "Stairs")
        {
            onLadder = false;
            rb.isKinematic = false;
            playerInput.SwitchCurrentActionMap("InGame");
        }
    }
}
