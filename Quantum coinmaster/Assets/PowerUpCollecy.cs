using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class powerUpCollect : MonoBehaviour
{

public Player player;

public bool isPowerUpCollected= false;

public int powerUp;

    void start() {
        if(isPowerUpCollected) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player")) {
            if(!isPowerUpCollected) {
               
                Destroy(gameObject);
                isPowerUpCollected = true;

            }
            

        }
        Debug.Log("powerUpCollecteds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
