using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    private float horizontal;
    public float speed = 3f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", horizontal == 0 ? false : true);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("isJumping", true);
        }
        if (context.canceled)
        {
            animator.SetBool("isJumping", false);
            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }

    public void Sit(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            animator.SetBool("isSitting", true);
        }
        if (context.canceled)
        {
            animator.SetBool("isSitting", false);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscake = transform.localScale;
            localscake.x *= -1f;
            transform.localScale = localscake;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
