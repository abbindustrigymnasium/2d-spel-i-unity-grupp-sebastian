using UnityEngine;
using System;

public class PowerUpIconMovement : MonoBehaviour
{
    //movement speed in units per second

    public bool dynamicYPos = true;
    private float testValue = 0f;

    


    public bool isActivated = false;

    public void ReturnTOBaseRotation() {
        transform.rotation = Quaternion.identity;
    }

    void start() {

    }

    void FixedUpdate()
    {

        testValue += 1;

        float positionY = (float)Math.Sin(testValue/10+transform.position.x);



        //update the position
        if (dynamicYPos) {
            transform.position = new Vector3(transform.position.x, positionY*4+40, 0);
        }

        if (isActivated) {
            transform.Rotate(0, 0, 2);
            transform.localScale = transform.localScale*2;
        }


        //output to log the position change

    }




}