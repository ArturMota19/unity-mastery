using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject impactShoot;
    void Start()
    {   
        // define component
        rb = GetComponent<Rigidbody2D>();
        // add velocity to the rigidbody
        rb.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        
    }

    // If one of them has isTrigger and other has Ridigbody2D, this function will work
    private void OnTriggerEnter2D(Collider2D other) {
        // object that has tag "Enemy" will be destroyed
        if(other.CompareTag("Enemy01"))
        {
            other.GetComponent<Enemy01Controller>().lossHealth(damage);
        }
        if(other.CompareTag("Player01"))
        {
            other.GetComponent<PlayerController>().lossHealth(damage);
        }

        Destroy(gameObject);
        Instantiate(impactShoot, transform.position, transform.rotation);
    }
}
