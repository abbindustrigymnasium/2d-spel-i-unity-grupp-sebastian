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
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        float positionX = (float)Math.Sin(testValue/10);



        //update the position
        transform.position = new Vector3(0, positionX, 0);

        transform.Rotate(0, 2, 0);

        //output to log the position change
        Debug.Log(positionX);
        Debug.Log(testValue);
    }
}