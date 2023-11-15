using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldBehaviourScript : MonoBehaviour
{


    public Player player;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            player.StartOverPlaying();

            
            
            

        }

    }

    public void teleportBack(){}

}
