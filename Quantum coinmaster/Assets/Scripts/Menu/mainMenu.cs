using System.Threading;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Player player;

    void start()
    {

    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        player.LoadPlayer();
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
    }
}
