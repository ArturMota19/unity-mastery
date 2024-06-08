using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {   
        // define component
        rb = GetComponent<Rigidbody2D>();
        // add velocity to the rigidbody
        rb.velocity = new Vector2(0, 10f);
    }

    void Update()
    {
        
    }
}
