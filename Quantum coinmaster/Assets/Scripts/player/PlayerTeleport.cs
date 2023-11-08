

using UnityEngine;
 using System.Threading;

public class PlayerTeleport : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 lastPosition;
    private bool isTeleporting = false;
    private float teleportDelay = 2.0f; // Set the delay time in seconds
    public bool isFlying = false;


    // Start is called before the first frame update
    void Start()
    {

        lastPosition = transform.position;
        Invoke("Saveposition", 3.0f);
    }

    public void Saveposition() {
        Invoke("Saveposition", 3.0f);
        lastPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6) && !isTeleporting) // Check for a key press or any other condition you want
        {
            Teleport();
            Debug.Log("hello");
        }

        
        if(isFlying) {
           if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }
        }




    }

    public void Teleport()
    {

        transform.position = lastPosition;
        // Add your custom logic here, e.g., play a rewind animation or any other effects.

        // After the teleport delay, the player will be teleported back.
    }



}
