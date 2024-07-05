using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject impactShoot;
    void Start()
    {   
        // define component
        rb = GetComponent<Rigidbody2D>();
        // add velocity to the rigidbody

    }

    void Update()
    {

    }

    // If one of them has isTrigger and other has Ridigbody2D, this function will work
    private void OnTriggerEnter2D(Collider2D other) {
        // object that has tag "Enemy" will be destroyed
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<ParentEnemy>().LossHealth(damage);
        }
        if(other.CompareTag("Player01"))
        {
            other.GetComponent<PlayerController>().LossHealth(damage);
        }

        Destroy(gameObject);
        Instantiate(impactShoot, transform.position, transform.rotation);
    }
}
