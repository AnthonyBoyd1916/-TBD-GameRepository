using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float horizontal;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 10f;
    private bool isFacingRight = true;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(horizontal > 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal < 0f)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void OnJump(/*InputAction.CallbackContext context*/)
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //if (/*context.canceled && */IsGrounded())
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //private void flip()
    //{
    //    isFacingRight = false;
    //    Vector3 localScale = transform.localScale;
    //    localScale.x *= -1f;
    //    transform.localScale = localScale;
    //}

    public void OnMove(InputValue axis)
    {
        horizontal = axis.Get<float>();
    }
}
