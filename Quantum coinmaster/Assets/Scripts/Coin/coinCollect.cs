using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class coinCollect : MonoBehaviour
{

public Player player;

public bool isCoinCollected = false;

    void start() {
        if(isCoinCollected) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player")) {
            if(!isCoinCollected) {
               
                Destroy(gameObject);
                isCoinCollected = true;
                player.CollectCoin();
                FindObjectOfType<AudioManager>().Play("coinCollect");
            }
            

        }
        Debug.Log("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
