using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float test = 8;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform cellingCheck;

    public bool isSliding = false;
    public bool canWalk = true;
    public bool canJump = true;

    public float speed = 8f;
    public float jumpingPower = 16f;

    public float slideSpeed = 2f;
    private float originalSlideSpeed;

    private float horizontal;
    private bool isFacingRight = true;
    Animator animator;

    public CapsuleCollider2D regularColl;
    public CapsuleCollider2D slideColl;


    // Start is called before the first frame update
    void Start()
    {
        isSliding = false;
        animator = GetComponent<Animator>();
        originalSlideSpeed = slideSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.bodyType == RigidbodyType2D.Static){ // används för att reseta animationerna vid spelardöd
            animator.SetBool("isSliding", false);
            animator.SetBool("isJumping", false);
            animator.SetFloat("xVelocity", 0);
            animator.SetFloat("yVelocity", 0);
        }else { // om dynamisk rigidbody -> spelare lever
            animator.SetBool("isSliding",isSliding);
            animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
            animator.SetFloat("yVelocity", rb.velocity.y);
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (isSliding == true)
            {
                rb.velocity = new Vector2(speed * slideSpeed, rb.velocity.y);
            }

            if (!isGrounded()&& !isSliding)
            {
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }

            if (!isFacingRight && horizontal > 0f)
            {
                if (canWalk)
                {
                    Flip();
                }
            }
            else if (isFacingRight && horizontal < 0f)
            {
                if (canWalk)
                {
                    Flip();
                }
            }
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private bool isCelling()
    {
        return Physics2D.OverlapCircle(cellingCheck.position, 1f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (canJump == true)
        {
            if (context.performed && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }

    public void Slide(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("isJumping",false);
            performSlide();
        }
    }

    private void performSlide()
    {
        canWalk = false;
        canJump = false;
        isSliding = true;

        if (originalSlideSpeed == slideSpeed)
        {
            if (isFacingRight != true)
            {
                slideSpeed *= -1;
            }
        }


        regularColl.enabled = false;
        slideColl.enabled = true;

        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.8f);
        while (isCelling())
        {
            yield return new WaitForSeconds(0.2f);
        }
        regularColl.enabled = true;
        slideColl.enabled = false;

        isSliding = false;
        canWalk = true;
        canJump = true;
        slideSpeed = originalSlideSpeed;
    }
}
