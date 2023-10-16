using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool isSliding = false;

    public float speed = 8f;
    public float jumpingPower = 16f;

    public float slideSpeed = 6f;

    private float horizontal;
    private bool isFacingRight = true;

    public BoxCollider2D regularColl;
    public BoxCollider2D slideColl;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
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
        if (context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Slide(InputAction.CallbackContext context)
    {
        performSlide();
    }

    private void performSlide()
    {
        isSliding = true;

        regularColl.enabled = false;
        slideColl.enabled = true;

        if (isFacingRight == true)
        {
            rb.AddForce(Vector2.right * slideSpeed);
        }
        else if (isFacingRight == false)
        {
            rb.AddForce(Vector2.right * slideSpeed * -1f);
        }



        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.8f);

        regularColl.enabled = true;
        slideColl.enabled = false;

        isSliding = false;

    }
}
