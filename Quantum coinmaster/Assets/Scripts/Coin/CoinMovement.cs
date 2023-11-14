
using UnityEngine;
using System;

public class CoinMovement : MonoBehaviour
{
    //movement speed in units per second

    public bool dynamicYPos = true;
    private float testValue = 0f;

    public float startingPosY;

    void start() {
        float startingPosY = transform.position.y;
    }

    void FixedUpdate()
    {

        testValue += 1;

        float positionY = ((float)Math.Sin(testValue/10))/10+transform.position.y;



        //update the position
        if (dynamicYPos) {
            transform.position = new Vector3(transform.position.x, positionY, 0);
        }


        transform.Rotate(0, 2, 0);

        //output to log the position change

    }
}