using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{

    public Button myButton;

    public Button ContinueButton;

    // Start is called before the first frame update
    void Start()
    {
                FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Stop("ambientSound1");
        FindObjectOfType<AudioManager>().Stop("ambientSound2");
        FindObjectOfType<AudioManager>().Stop("ambientSound3");
        FindObjectOfType<AudioManager>().Stop("ambientSound4");
        FindObjectOfType<AudioManager>().Stop("ambientSound5");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            myButton.onClick.Invoke();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            ContinueButton.onClick.Invoke();
        }
    }

    public void PauseSound() {
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Stop("ambientSound1");
        FindObjectOfType<AudioManager>().Stop("ambientSound2");
        FindObjectOfType<AudioManager>().Stop("ambientSound3");
        FindObjectOfType<AudioManager>().Stop("ambientSound4");
        FindObjectOfType<AudioManager>().Stop("ambientSound5");
    }
}
