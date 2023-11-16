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
    public BenTimeLine_Lab IntroCutscene;
    public bool useIntro;
    public int chosenIndex;

    private AudioSource source;

    private int index;
    private int charIndex;
    private bool started;
    private bool waitForNext;

    public float fadeOutTime = 0.1f;
    private void ToggleWindow(bool show){
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show){
        indicator.SetActive(show);
    }
    private void Awake(){
        ToggleWindow(false);
        ToggleIndicator(false);
        source = GetComponent<AudioSource>();
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
        StopCoroutine( FadeOut());
        source.volume = 1;
        PlayAudioFromRandomPoint();
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
        source.Stop();
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
            source.Stop();
            
        }
    }
    private void Update()
    {
        if(waitForNext && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))){
            waitForNext = false;
            index++;

            if(index < dialogues.Count){
                if(useIntro && index == chosenIndex){
                    IntroCutscene.AnimateScientist();
                }
                retrieveDialogue(index);
            }else{
                EndDialogue();
                source.Stop();
                

                if(useIntro){
                    IntroCutscene.AnimatePortal();
                    IntroCutscene.PlayTimeline();
                }
            }
        }
    }

        public void FadeOutAudio()
    {

            StartCoroutine(FadeOut());

    }

    // Coroutine for fading out the audio
    private System.Collections.IEnumerator FadeOut()
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / fadeOutTime;

            yield return null;
        }

        // Make sure the volume is set to 0 after fading out
        source.volume = 0;

        // Stop the audio after fading out
        source.Stop();
        source.volume = 1;
    }

        private void PlayAudioFromRandomPoint()
    {
        if (source != null)
        {
            // Set the time to a random point within the audio clip length
            source.time = Random.Range(0, source.clip.length);

            // Play the audio
            source.Play();
        }
    }
}
