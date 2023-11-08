using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn_on_collision : MonoBehaviour
{
    public float despawnDelay = 2.0f; // Adjust the delay as needed

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Call the Despawn method with a delay
        Invoke("Despawn", despawnDelay);
    }

    private void Despawn()
    {
        // This method will be called after the delay, and you can destroy the object here
        Destroy(gameObject);
    }
}