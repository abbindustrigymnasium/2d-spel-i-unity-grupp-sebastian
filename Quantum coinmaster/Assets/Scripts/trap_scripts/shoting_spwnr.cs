using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoting_spwnr : MonoBehaviour
{
    public GameObject laser;

    public float spawnRate = 2;
    private float timer = 0;

    public float random = 1;

    public range = 100;
    private pos = 0;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < spawnRate)
        {
            //FIX DESPAWN
            timer = timer + Time.deltaTime;
        }
        else
        {
            Instantiate(laser, transform.position, transform.rotation);
            timer = 0 + Random.Range(-random, random);

        }
        if (transform.position.x > pos + range)
        {
            Destroy(laser);
        }
    }
}
