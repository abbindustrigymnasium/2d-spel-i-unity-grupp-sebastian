using System.Threading;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public Player player;

    public Save save;

    public Car saveData = new Car();

    public GameObject loadingScreen;



    void start()
    {

    }
    // Start is called before the first frame update

    public void NewGame() {
          loadingScreen.SetActive(true);
          SceneManager.LoadScene("IntroCutScene");


    }

    public void LoadGame() {
        loadingScreen.SetActive(true);
        Car data = Save.LoadFile();
        string currentSceneName = data.level;
        SceneManager.LoadScene(currentSceneName);
        player.LoadPlayer();

    }
    public void PlayGame()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        SceneManager.LoadScene(currentSceneName);

    }
    public void mainMenu()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    void update()
    {
       /* if (Input.GetKeyDown("enter"))
        {
            PlayGame();
        } */
    }
}
