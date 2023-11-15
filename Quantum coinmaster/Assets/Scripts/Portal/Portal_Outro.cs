using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Outro : MonoBehaviour
{
    public Transform trap;
    public float speed;
    public float yBottom;
    public float yTop;


    private Vector3 OriginalPos;

    void Start()
    {
        OriginalPos = trap.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = trap.position;

        if (trap.position.y > yBottom - speed)
        {
            targetPosition = new Vector3(trap.position.x, trap.position.y - speed, trap.position.z);
        }
        else if (trap.position.y < yBottom)
        {
            targetPosition = OriginalPos;
        }

        trap.position = targetPosition;
    }
}
