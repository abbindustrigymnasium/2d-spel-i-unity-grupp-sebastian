using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_laser : MonoBehaviour
{
    public Transform laser;
    public Transform laserSpawner;
    public float speed;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public float timeGoal = 100;
    public float currentTime = 0;



    // Start is called before the first frame update
    void Start()
    {
        if (laserSpawner.localScale.y < 0)
        {
            speed = speed * -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = laser.position;
        targetPosition = new Vector3(laser.position.x, laser.position.y - speed, laser.position.z);
        laser.position = targetPosition;
        currentTime = currentTime + Time.deltaTime;

        if (isGrounded() == true)
        {
            Destroy(gameObject);
        }
        if (currentTime > timeGoal)
        {
            Destroy(gameObject);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
}
