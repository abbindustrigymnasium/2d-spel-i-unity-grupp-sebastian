

using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    public bool superDrugPowerOn = true;
    public bool flyingPowerOn = true;

    public bool invisibilityPowerOn = true;

    public bool douleJumpingPowerOn = true;

    //public float speed = 8f;

    private bool isCooldown = false;

    public float cooldownDuration = 20.0f;

    public float[] powerUpDuration = {5.0f, 5.0f, 10.0f, 20.0f, 30.0f};

    public bool[] isActivePowerUp = new bool[5];

    public PlayerMovement movement;

    public KillAndRespawn killAndRespawn;

    public int speedMultiplier = 1;

    public Image powerUpBackground;

    public Color SuperDrugBackgroundColor = new Color();

    public Color invincibilityBackgroundColor= new Color();

     public Color doubleJumpBackgroundColor = new Color();

    public Color moonGravityBackgroundColor = new Color();


    public Color FlyingBackgroundColor = new Color();
    public float a = 0.0005f;

    public PowerUpIconMovement superDrugIconMovement;

        public PowerUpIconMovement invinsibilityIconMovement;

        public PowerUpIconMovement doubleJumpIconMovement;

        public PowerUpIconMovement moonGravityIconMovement;
        public PowerUpIconMovement flyingIconMovement;


    public void Start()
    {
       Color backgroundColor = powerUpBackground.color;
        backgroundColor.a =0.5f;

        powerUpBackground.color = backgroundColor;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(speed);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SuperDrugPowerUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            InvinsibilityPowerUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            DoubleJumpPowerUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            MoonGravity();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            FlyingPowerUp();
        }

        if (isActivePowerUp[0]) {
            powerUpBackground.color = SuperDrugBackgroundColor;
            SuperDrugBackgroundColor.a = SuperDrugBackgroundColor.a-a;
            Debug.Log(SuperDrugBackgroundColor.a);
            powerUpBackground.color = SuperDrugBackgroundColor;


        }



    }

    private void ResetCooldown()
    {
        isCooldown = false;
    }


    public void PowerUpAnimation() {
        
    }

    private void PowerDownSuperdrug()
    {
        movement.speed = movement.speed/3;
        isActivePowerUp[0] = false;
        superDrugIconMovement.isActivated = false;
        superDrugIconMovement.ReturnTOBaseRotation();
        Invoke("ResetCooldownS", cooldownDuration);

    }

    private void PowerDownInvinsibility() {
        killAndRespawn.isInvinsable = false;
        Invoke("ResetCooldown", cooldownDuration);
    }

    private void PowerDownDoubleJump() {
        movement.doubleJumpOn = false;
        Invoke("ResetCooldown", cooldownDuration);
    }

    private void PowerDownMoonGravity() {
        movement.rb.gravityScale = movement.rb.gravityScale*3;
        Invoke("ResetCooldown", cooldownDuration);
    }

    private void PowerDownFlying() {
        Invoke("ResetCooldown", cooldownDuration); 
    }

    public void SuperDrugPowerUp()
    {
        if (!isCooldown)
        {
            Debug.Log("SuperdrugPowerUp");
            movement.speed = movement.speed * 3;
            isCooldown = true;
            Invoke("PowerDownSuperdrug", powerUpDuration[0]);

            SuperDrugBackgroundColor.a = 0.7f;
            isActivePowerUp[0] = true;
            superDrugIconMovement.isActivated = true;
            
        }
    }

    public void FlyingPowerUp()
    {
        if(!isCooldown) {
            Debug.Log("FlyingPowerUp");
            isCooldown = true;
            Invoke("PowerDownFlying", powerUpDuration[5]);

        }
    }

    public void InvinsibilityPowerUp()
    {
        if (!isCooldown)
        {
            Debug.Log("InvinsibilityPowerUp");
            killAndRespawn.isInvinsable = true;
            isCooldown = true;
            Invoke("PowerDownInvinsibility", powerUpDuration[1]);

        }

    }

    public void DoubleJumpPowerUp()
    {
        if (!isCooldown)
        {
            Debug.Log("DoubleJumpPowerUp");
            movement.doubleJumpOn = true;
            isCooldown = true;
            Invoke("PowerDownDoubleJump", powerUpDuration[2]);

        }
    }

    public void MoonGravity() {
                if (!isCooldown)
        {
            Debug.Log("Moon Gravity");
            movement.rb.gravityScale = movement.rb.gravityScale/3;

            isCooldown = true;
            Invoke("PowerDownMoonGravity", powerUpDuration[3]);

        }
    }
}
