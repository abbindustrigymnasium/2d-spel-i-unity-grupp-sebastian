using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_x : MonoBehaviour
{
    public Transform trap;

    public float speed;

    public float xLeft;
    public float xRight;

    private bool goingLeft = false;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = trap.position; // Declare targetPosition outside

        if (trap.position.x < xRight + speed && !goingLeft)
        {
            targetPosition = new Vector3(trap.position.x + speed, trap.position.y, trap.position.z);
            if (trap.position.x > xRight)
            {
                goingLeft = true;
            }
        }
        else if (trap.position.x > xLeft - speed && goingLeft) // Typo fix: goingUp instead of going
        {
            targetPosition = new Vector3(trap.position.x - speed, trap.position.y, trap.position.z);
            if (trap.position.x < xLeft)
            {
                goingLeft = false;
            }
        }

        trap.position = targetPosition; // Apply the targetPosition
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("HELLLLLLLOOOO");
            player.position = new Vector3(trap.position.x, trap.position.y, trap.position.z);
        }
    }
}
