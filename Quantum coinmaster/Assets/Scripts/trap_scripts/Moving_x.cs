using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_x : MonoBehaviour
{
    public Transform trap;

    public float speed;

    public float realSpeed = 0;

    public float xLeft;
    public float xRight;

    private bool goingLeft = false;

    public Transform player;
    public Rigidbody2D rbPlayer;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (trap.position.x < xRight + speed && !goingLeft)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (trap.position.x > xRight)
            {
                goingLeft = true;
            }
        }
        else if (trap.position.x > xLeft - speed && goingLeft) // Typo fix: goingUp instead of going
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (trap.position.x < xLeft)
            {
                goingLeft = false;
            }
        }
        if (realSpeed != 0)
        {
            realSpeed = rb.velocity.x;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            realSpeed = rb.velocity.x;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            realSpeed = 0;
        }
    }
}
