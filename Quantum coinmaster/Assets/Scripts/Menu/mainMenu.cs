using System.Threading;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    void start()
    {

    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    void update()
    {
        if (Input.GetKeyDown("enter"))
        {
            PlayGame();
        }
        Time.timeScale = 0;
    }
}
