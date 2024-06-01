using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D ballRB;
    public Vector2 ballVelocity;
    private float speed = 8f;

    
    void Start()
    {   
        ballVelocity.x = -speed;
        ballRB.velocity = ballVelocity;
    }

    void Update()
    {
    }
}
