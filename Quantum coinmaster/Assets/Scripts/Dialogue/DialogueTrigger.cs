using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Player player;
    public Dialogue dialogueScript;
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
        if(playerDetected && Input.GetKeyDown(KeyCode.E)){
            dialogueScript.StartDialogue();
            player.SavePlayer();
            Debug.Log("SeucessFully Saved");
        }
    }
}
