using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class powerUpCollect : MonoBehaviour
{

public Player player;

    public Dialogue dialogueScript;


public int powerUpId = 0;

public PowerUps powerUp;

    void start() {

    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
       
          
               
                
                dialogueScript.StartDialogue();
                if (powerUpId == 1) {
                    powerUp.superDrugPowerUpOn = true;
                }
                else if (powerUpId == 2)  {
                    powerUp.invisibilityPowerUpOn = true;
                }
                else if  (powerUpId == 3) {
                    powerUp.doubleJumpingPowerUpOn = true;
                }
                else if (powerUpId == 4)  {
                    powerUp.moonGravityPowerUpOn = true;
                }
                else if (powerUpId == 5)  {
                    powerUp.flyingPowerUpOn = true;
                }
            
        

        FindObjectOfType<AudioManager>().Play("coinCollect");
        Debug.Log("powerUpCollecteds");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
