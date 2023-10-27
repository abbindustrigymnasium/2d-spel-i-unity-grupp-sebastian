using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Moving : MonoBehaviour
{
    public Transform trap;

    public float speed;

    public float yBottom;
    public float yTop;

    private bool goingUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = trap.position; // Declare targetPosition outside

        if (trap.position.y > yBottom - speed && !goingUp) // Typo fix: goingUp instead of going
        {
            targetPosition = new Vector3(trap.position.x, trap.position.y - speed, trap.position.z);
            if (trap.position.y < yBottom)
            {
                goingUp = true;
            }
        }
        else if (trap.position.y < yTop + speed && goingUp) // Typo fix: goingUp instead of going
        {
            targetPosition = new Vector3(trap.position.x, trap.position.y + speed, trap.position.z);
            if (trap.position.y > yTop)
            {
                goingUp = false;
            }
        }

        trap.position = targetPosition; // Apply the targetPosition
    }
}
