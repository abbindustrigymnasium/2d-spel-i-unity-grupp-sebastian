using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillandRespawn : MonoBehaviour
{
    public Rigidbody2D rb;
    //private Animator anim;

    public GameObject objectToActivate;

    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // anim = getComponent<Animator>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("trap"))
        {
            Debug.Log("Hello");
            Die();
            
            gameManager.pauseGame();
            objectToActivate.SetActive(true);
           

            //Remove this part once animation is here!!
            //RestartLevel();
        }

    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
