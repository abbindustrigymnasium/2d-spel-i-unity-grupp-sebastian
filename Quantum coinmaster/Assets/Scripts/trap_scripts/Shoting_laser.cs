using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting_laser : MonoBehaviour
{
    public Transform laser;
    public Transform laserSpawner;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (laserSpawner.localScale.x < 0)
        {
            speed = speed * -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = laser.position;
        targetPosition = new Vector3(laser.position.x - speed, laser.position.y, laser.position.z);
        laser.position = targetPosition;
    }
}
