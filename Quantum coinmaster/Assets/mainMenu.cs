using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
    public void QuitGame() {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
