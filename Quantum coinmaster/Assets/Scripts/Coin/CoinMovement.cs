using UnityEngine;
using System;

public class CoinMovement : MonoBehaviour
{
    //movement speed in units per second

    public bool dynamicYPos = true;
    private float testValue = 0f;

    void start() {

    }

    void FixedUpdate()
    {

        testValue += 1;

        float positionY = (float)Math.Sin(testValue/10);



        //update the position
        if (dynamicYPos) {
            transform.position = new Vector3(transform.position.x, positionY, 0);
        }


        transform.Rotate(0, 2, 0);

        //output to log the position change

    }
}