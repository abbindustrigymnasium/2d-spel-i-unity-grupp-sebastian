
using System.Threading;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PowerUpIconMovement : MonoBehaviour
{
    //movement speed in units per second

    public bool dynamicYPos = true;
    private float testValue = 0f;

    public Image PowerUpImage;

    public Color color = new Color();


    public bool isActivated = false;

    public float b = 0;

    private float a = 0.005f;

    public bool inRecovery = false;

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
            color = PowerUpImage.color;
            color.a = color.a-a;
            PowerUpImage.color = color;
            transform.Rotate(0, 0, 2);
        }

        if (inRecovery) {
            ReturnTOBaseRotation();
            color = PowerUpImage.color;
            color.a = color.a+(a*0.25f);
            PowerUpImage.color = color;
        }


        //output to log the position change

    }

    public void SetIconColor(Color newColor) {
        //newColor.a
        PowerUpImage.color = newColor;
    }




}