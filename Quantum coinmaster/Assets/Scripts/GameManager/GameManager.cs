using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void pauseGame() {
        FindObjectOfType<AudioManager>().Pause("Theme");
        FindObjectOfType<AudioManager>().Pause("ambientSound1");
        FindObjectOfType<AudioManager>().Pause("ambientSound2");
        FindObjectOfType<AudioManager>().Pause("ambientSound3");
        FindObjectOfType<AudioManager>().Pause("ambientSound4");
        FindObjectOfType<AudioManager>().Pause("ambientSound5");
        Time.timeScale = 0;

    }

    public void continueGame() {
        Time.timeScale = 1;
                FindObjectOfType<AudioManager>().Resume("Theme");
        FindObjectOfType<AudioManager>().Resume("ambientSound1");
        FindObjectOfType<AudioManager>().Resume("ambientSound2");
        FindObjectOfType<AudioManager>().Resume("ambientSound3");
        FindObjectOfType<AudioManager>().Resume("ambientSound4");
        FindObjectOfType<AudioManager>().Resume("ambientSound5");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
