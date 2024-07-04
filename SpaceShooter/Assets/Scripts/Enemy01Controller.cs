using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Controller : ParentEnemy
{

    // Get rigidbody2D component
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        // random shootTime
        shootTime = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

}
