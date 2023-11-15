using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class KillAndRespawn : MonoBehaviour
{
    //public PlayerMovement playerMovement;
    public Rigidbody2D rb;
    private Animator anim;
    private PlayerMovement playerMovement;
    //private Animator anim;

    public GameObject objectToActivate;

    public GameManager gameManager;

    public bool isInvinsable = false;

    public PlayerTeleport playerTeleport;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // anim = getComponent<Animator>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            if (!isInvinsable) {
                 Die();
            }
            else {
                playerTeleport.Teleport();
            }
        }

    }
    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        FindObjectOfType<AudioManager>().Play("death");
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        objectToActivate.SetActive(true);
        gameManager.pauseGame();
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Stop("ambientSound1");
        FindObjectOfType<AudioManager>().Stop("ambientSound2");
        FindObjectOfType<AudioManager>().Stop("ambientSound3");
        FindObjectOfType<AudioManager>().Stop("ambientSound4");
        FindObjectOfType<AudioManager>().Stop("ambientSound5");
        Debug.Log("Dead");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }




}
