using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Controller : ParentEnemy
{
    // Get rigidbody2D component
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        // random shootTime
        shootTime = Random.Range(0.25f, 1.75f);
    }

    // Update is called once per frame
    void Update()
    {
        GuidedShooting();

        if(transform.position.y < yMax && !hasMoved){
            hasMoved = true;
            if(transform.position.x < 0){
                rb.velocity = new Vector2(-speed , speed);
            }else{
                rb.velocity = new Vector2(speed, speed);
            }
        }

    }

    
}
