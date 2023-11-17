using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public string newLevel;

    public Player player;


    public Transform playerTransform;
    public Vector2 startingPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform.position = startingPos;
            player.SavePlayer(newLevel);
            
            SceneManager.LoadScene(newLevel);
        }

    }

    public void teleportBack(){}

}
