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
        Time.timeScale = 0;
    }

    public void continueGame() {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
