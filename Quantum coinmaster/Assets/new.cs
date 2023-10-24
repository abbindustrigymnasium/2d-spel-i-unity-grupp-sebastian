using UnityEngine;
using System;

public class test : MonoBehaviour
{
    //movement speed in units per second
    private float movementSpeed = 5f;
    private float testValue = 0f;

    void start() {

    }

    void FixedUpdate()
    {

        testValue += 1;

        float positionY = (float)Math.Sin(testValue/10);



        //update the position
        transform.position = new Vector3(transform.position.x, positionY, 0);

        transform.Rotate(0, 2, 0);

        //output to log the position change

    }
}