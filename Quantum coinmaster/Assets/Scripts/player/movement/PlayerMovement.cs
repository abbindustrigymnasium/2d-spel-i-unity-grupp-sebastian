using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
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

    public BoxCollider2D regularColl;
    public BoxCollider2D slideColl;


    // Start is called before the first frame update
    void Start()
    {
        originalSlideSpeed = slideSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canWalk == true)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else if (canWalk == false && isSliding == true)
        {
            rb.velocity = new Vector2(speed * slideSpeed, rb.velocity.y);
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

        Debug.Log("Hello Test");
        regularColl.enabled = true;
        slideColl.enabled = false;

        isSliding = false;
        canWalk = true;
        canJump = true;
        slideSpeed = originalSlideSpeed;



    }
}
