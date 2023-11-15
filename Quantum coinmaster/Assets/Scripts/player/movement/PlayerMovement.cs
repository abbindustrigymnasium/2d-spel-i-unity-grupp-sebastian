using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool play = true;
    public PowerUps powerUps;

    public float test = 8;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform cellingCheck;

    public bool isSliding = false;
    public bool canWalk = true;
    public bool canJump = true;

    private bool doubleJump = false;

    public float speed = 8f;
    public float jumpingPower = 16f;

    public float slideSpeed = 2f;
    private float originalSlideSpeed;

    private float horizontal;
    private bool isFacingRight = true;
    Animator animator;

    public CapsuleCollider2D regularColl;
    public CapsuleCollider2D slideColl;

    public BoxCollider2D boxColl;

    public bool doubleJumpOn = false;

    public float jumpForce = 500.0f;
    public Moving_x moving_x;


    // Start is called before the first frame update
    void Start()
    {
        isSliding = false;
        animator = GetComponent<Animator>();
        originalSlideSpeed = slideSpeed;
    }

    /*public float updateSpeed() {
        float speed = powerUps.speed;
        return speed;
    } */

    // Update is called once per frame
    void FixedUpdate()
    {
       
        //Debug.Log(speed);
        if (rb.bodyType == RigidbodyType2D.Static)
        { // används för att reseta animationerna vid spelardöd
            animator.SetBool("isSliding", false);
            animator.SetBool("isJumping", false);
            animator.SetFloat("xVelocity", 0);
            animator.SetFloat("yVelocity", 0);
        }
        else
        { // om dynamisk rigidbody -> spelare lever
            animator.SetBool("isSliding", isSliding);
            animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
            animator.SetFloat("yVelocity", rb.velocity.y);
            rb.velocity = new Vector2(horizontal * speed + moving_x.realSpeed, rb.velocity.y);
            if (isSliding == true)
            {
                rb.velocity = new Vector2(speed * slideSpeed, rb.velocity.y);
            }


            if (!isGrounded() && !isSliding)
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
            if (context.performed && (isGrounded() || (doubleJump && doubleJumpOn)) )
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                doubleJump = !doubleJump;



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
            animator.SetBool("isJumping", false);
            performSlide();
        }
    }

    private void performSlide()
    {
        canWalk = false;
        canJump = false;
        isSliding = true;
        FindObjectOfType<AudioManager>().Play("slide");
                FindObjectOfType<AudioManager>().Play("slide2");

        if (originalSlideSpeed == slideSpeed)
        {
            if (isFacingRight != true)
            {
                slideSpeed *= -1;
            }
        }


        regularColl.enabled = false;
        slideColl.enabled = true;
        boxColl.enabled = false;

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
        boxColl.enabled = true;

        isSliding = false;
        canWalk = true;
        canJump = true;
        slideSpeed = originalSlideSpeed;
    }



    void Update()
    {
        


        if (isGrounded() && play) {
            FindObjectOfType<AudioManager>().Play("groundHit");
            play = false;
        }

        if (!isGrounded() && !play) {
            play = true;
        
    }

}

}