using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public GameObject window;
    public GameObject indicator;
    public List<string> dialogues;
    public TMP_Text dialogueText;
    public float writingSpeed;

    public Player player;

    private int index;
    private int charIndex;
    private bool started;
    private bool waitForNext;
    private void ToggleWindow(bool show){
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show){
        indicator.SetActive(show);
    }
    private void Awake(){
        ToggleWindow(false);
        ToggleIndicator(false);
    }
    public void StartDialogue(){
        if(started)
            return;
        started = true;
        ToggleWindow(true); // toggle window, to be visible
        ToggleIndicator(false); // remove indicator
        retrieveDialogue(0); // initial dialogue
    }
    private void retrieveDialogue(int i){
        // the index is changed to dialogue i
        index = i;
        // charindex, start new sentence
        charIndex = 0;
        // empty the dialogue
        dialogueText.text = string.Empty;
        // start typewriting
        StartCoroutine(Writing());
    }
    public void EndDialogue(){
        started = false;
        waitForNext = false;
        StopAllCoroutines();
        ToggleWindow(false);
    }
    IEnumerator Writing(){
        // current sentence
        yield return new WaitForSeconds(writingSpeed);
        string currentDialogue = dialogues[index];
        // add char to sentence
        dialogueText.text += currentDialogue[charIndex];
        //update index
        charIndex++;
        if(charIndex < currentDialogue.Length){
            yield return new WaitForSeconds(writingSpeed);
            StartCoroutine(Writing());
        }else{
            waitForNext = true;
        }
    }
    private void Update()
    {
        if(waitForNext && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))){
            waitForNext = false;
            index++;
            if(index < dialogues.Count){
                retrieveDialogue(index);
            }else{
                EndDialogue();
                

            }
        }
    }
}
