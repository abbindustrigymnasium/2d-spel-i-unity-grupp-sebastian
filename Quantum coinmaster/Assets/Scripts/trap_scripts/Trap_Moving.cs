using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Moving : MonoBehaviour
{
    public Transform trap;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(trap.position.x + speed, trap.position.y, trap.position.z);

        trap.position = targetPosition;

    }
}
