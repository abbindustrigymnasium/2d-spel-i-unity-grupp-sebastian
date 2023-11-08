


using System.Globalization;
using System.ComponentModel;
using System.Timers;
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
    public bool superDrugPowerUpOn = true;
    public bool flyingPowerUpOn = true;
    public bool invisibilityPowerUpOn = true;
    public bool doubleJumpingPowerUpOn = true;
    public bool moonGravityPowerUpOn = true;
    //public float speed = 8f;
    private bool isCooldown = false;

    public float cooldownDuration = 20.0f;

    public float[] powerUpDuration = { 5.0f, 5.0f, 5.0f, 5.0f, 5.0f };

    public bool isActivePowerUp = false;
    public PlayerMovement movement;
    public KillAndRespawn killAndRespawn;
    public int speedMultiplier = 1;
    public Image powerUpBackground;
    public Color backgroundColor = new Color();

    public Color iconColor = new Color();

    public Color activeIconColor = new Color();

    public float a = 0.1f;

    public PowerUpIconMovement superDrugIconMovement;

    public PowerUpIconMovement invinsibilityIconMovement;

    public PowerUpIconMovement doubleJumpIconMovement;

    public PowerUpIconMovement moonGravityIconMovement;
    public PowerUpIconMovement flyingIconMovement;

    public PlayerTeleport playerTeleport;

    private float elapsedTime = 0.0f;



    public void Start()
    {
        superDrugIconMovement.GameObjectVisibility(superDrugPowerUpOn);
        invinsibilityIconMovement.GameObjectVisibility(invisibilityPowerUpOn);
        doubleJumpIconMovement.GameObjectVisibility(doubleJumpingPowerUpOn);
        moonGravityIconMovement.GameObjectVisibility(moonGravityPowerUpOn);
        flyingIconMovement.GameObjectVisibility(flyingPowerUpOn);
    }

    // Update is called once per frame
    void Update()

    {
        //Debug.Log(speed);
        


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SuperDrugPowerUp();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InvinsibilityPowerUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DoubleJumpPowerUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoonGravity();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FlyingPowerUp();
        }

        if (isActivePowerUp)
        {
            powerUpBackground.color = backgroundColor;

            backgroundColor.a = 0.7f - (elapsedTime * a);
            //Debug.Log(SuperDrugbackgroundColor.a);
            //Debug.Log(backgroundColor.a);
            //Debug.Log(elapsedTime);

            
        elapsedTime += Time.deltaTime;

        }

        if (isCooldown) {
            iconColor = new Color(1.0f-(elapsedTime*a), 1.0f-(elapsedTime*a), 1.0f-(elapsedTime*a));
            //Debug.Log(iconColor);
            //Debug.Log(elapsedTime);
            elapsedTime += Time.deltaTime;
            superDrugIconMovement.SetIconColor(iconColor);
            invinsibilityIconMovement.SetIconColor(iconColor);
            doubleJumpIconMovement.SetIconColor(iconColor);
            moonGravityIconMovement.SetIconColor(iconColor);
            flyingIconMovement.SetIconColor(iconColor);

            //Debug.Log(iconColor);
        }




    }



    private void ResetCooldown()
    {
        isCooldown = false;
        superDrugIconMovement.inRecovery = false;
        Debug.Log("Ready to click!");

                    iconColor = activeIconColor;
            superDrugIconMovement.SetIconColor(iconColor);
            invinsibilityIconMovement.SetIconColor(iconColor);
            doubleJumpIconMovement.SetIconColor(iconColor);
            moonGravityIconMovement.SetIconColor(iconColor);
            flyingIconMovement.SetIconColor(iconColor);
            elapsedTime = 0;
        


    }


    public void PowerUpAnimation()
    {

    }

    private void PowerDownSuperdrug()
    {
        movement.speed = movement.speed / 3;
        isActivePowerUp = false;
        superDrugIconMovement.isActivated = false;
        superDrugIconMovement.inRecovery = true;
        Invoke("ResetCooldown", cooldownDuration);

    }

    private void PowerDownInvinsibility()
    {
        killAndRespawn.isInvinsable = false;
        Invoke("ResetCooldown", cooldownDuration);
        isActivePowerUp = false;
        invinsibilityIconMovement.isActivated = false;
        invinsibilityIconMovement.inRecovery = true;

    }

    private void PowerDownDoubleJump()
    {
        movement.doubleJumpOn = false;
        Invoke("ResetCooldown", cooldownDuration);
        isActivePowerUp = false;
        doubleJumpIconMovement.isActivated = false;
        doubleJumpIconMovement.inRecovery = true;

    }

    private void PowerDownMoonGravity()
    {
        movement.rb.gravityScale = movement.rb.gravityScale * 3;
        Invoke("ResetCooldown", cooldownDuration);
        isActivePowerUp = false;
        moonGravityIconMovement.isActivated = false;
        moonGravityIconMovement.inRecovery = true;

    }

    private void PowerDownFlying()
    {
        Invoke("ResetCooldown", cooldownDuration);
        isActivePowerUp = false;
        flyingIconMovement.isActivated = false;
        flyingIconMovement.inRecovery = true;
        playerTeleport.isFlying = false;

    }

    public void SuperDrugPowerUp()
    {
        if (!isCooldown && invisibilityPowerUpOn)
        {
            Debug.Log("SuperdrugPowerUp");
            movement.speed = movement.speed * 3;
            isCooldown = true;
            Invoke("PowerDownSuperdrug", powerUpDuration[0]);

            backgroundColor.a = 0.4f;
            isActivePowerUp = true;
            superDrugIconMovement.isActivated = true;

        }
    }

    public void FlyingPowerUp()
    {
        if (!isCooldown && flyingPowerUpOn)
        {
            Debug.Log("FlyingPowerUp");
            isCooldown = true;
            Invoke("PowerDownFlying", powerUpDuration[4]);
            backgroundColor.a = 0.4f;
            isActivePowerUp = true;
            flyingIconMovement.isActivated = true;
            playerTeleport.isFlying = true;
        }
    }

    public void InvinsibilityPowerUp()
    {
        if (!isCooldown && invisibilityPowerUpOn)
        {
            Debug.Log("InvinsibilityPowerUp");
            killAndRespawn.isInvinsable = true;
            isCooldown = true;
            Invoke("PowerDownInvinsibility", powerUpDuration[1]);

            backgroundColor.a = 0.4f;
            isActivePowerUp = true;
            invinsibilityIconMovement.isActivated = true;

        }

    }

    public void DoubleJumpPowerUp()
    {
        if (!isCooldown && doubleJumpingPowerUpOn)
        {
            Debug.Log("DoubleJumpPowerUp");
            movement.doubleJumpOn = true;
            isCooldown = true;
            Invoke("PowerDownDoubleJump", powerUpDuration[2]);

            backgroundColor.a = 0.4f;
            isActivePowerUp = true;
            doubleJumpIconMovement.isActivated = true;

        }
    }

    public void MoonGravity()
    {
        if (!isCooldown && moonGravityPowerUpOn)
        {
            Debug.Log("Moon Gravity");
            movement.rb.gravityScale = movement.rb.gravityScale / 3;

            isCooldown = true;
            Invoke("PowerDownMoonGravity", powerUpDuration[3]);


            backgroundColor.a = 0.4f;
            isActivePowerUp = true;
            moonGravityIconMovement.isActivated = true;


        }
    }


}
