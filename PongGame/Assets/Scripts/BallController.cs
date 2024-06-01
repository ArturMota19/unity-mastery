using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D ballRB;
    public Vector2 ballVelocity;
    private float speed = 10f;

    
    void Start()
    {   
        // random to generate 1 or -1
        float range = Random.Range(0, 2) == 0 ? -1 : 1;

        ballVelocity.x = range * speed; // ball goes to the left or right
        ballVelocity.y = range * speed; // ball goes up or down
        ballRB.velocity = ballVelocity;
    }

    void Update()
    {
        // increment ball velocity
    }
}
