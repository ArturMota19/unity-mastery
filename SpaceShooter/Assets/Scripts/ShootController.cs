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

    // If one of them has isTrigger and other has Ridigbody2D, this function will work
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
