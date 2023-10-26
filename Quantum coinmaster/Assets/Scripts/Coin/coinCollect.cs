using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class coinCollect : MonoBehaviour
{

public Player player;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player")) {

            Destroy(gameObject);
            player.CollectCoin();
        }
        Debug.Log("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
