using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_Something : MonoBehaviour
{

    public Transform thing_to_Follow;
    public Transform follower;

    public float xSpeed;
    public float ySpeed;

    public float xStart;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 targetPosition = new Vector3(thing_to_Follow.position.x - thing_to_Follow.position.x * xSpeed + xStart, 0f - thing_to_Follow.position.y * ySpeed, follower.position.z);

        follower.position = targetPosition;
    }
}
