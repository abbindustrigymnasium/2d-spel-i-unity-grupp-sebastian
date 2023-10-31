using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_x : MonoBehaviour
{
    public Transform trap;

    public float speed;

    public float xLeft;
    public float xRight;

    private bool goingUp = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = trap.position; // Declare targetPosition outside

        if (trap.position.x > xLeft - speed && !goingUp) // Typo fix: goingUp instead of going
        {
            targetPosition = new Vector3(trap.position.x - speed, trap.position.y, trap.position.z);
            if (trap.position.x < yLeft)
            {
                goingUp = true;
            }
        }
        else if (trap.position.y < yTop + speed && goingUp) // Typo fix: goingUp instead of going
        {
            targetPosition = new Vector3(trap.position.x + speed, trap.position.y, trap.position.z);
            if (trap.position.x > yRight)
            {
                goingUp = false;
            }
        }

        trap.position = targetPosition; // Apply the targetPosition
    }
}
