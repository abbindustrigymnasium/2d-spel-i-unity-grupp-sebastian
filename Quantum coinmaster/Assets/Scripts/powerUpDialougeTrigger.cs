using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDialogueTrigger : MonoBehaviour
{
    public Player player;
    private bool input;
    public Dialogue dialogueScript;
    public bool removeCode;
    private bool isTriggered = false;
    private bool playerDetected;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player")
        {
            dialogueScript.StartDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
    }
    private void Update(){
        if (removeCode){
            isTriggered = true;
            removeCode = false;
            dialogueScript.StartDialogue();
        } else {
            if(!isTriggered && (playerDetected)){
                dialogueScript.StartDialogue();

            }
        }
    }
}
