using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool input;
    public Dialogue dialogueScript;
    public bool removeCode;
    private bool isTriggered = false;
    private bool playerDetected;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
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
            if(!isTriggered && (playerDetected && Input.GetKeyDown(KeyCode.E))){
                dialogueScript.StartDialogue();
            }
        }
    }
}
