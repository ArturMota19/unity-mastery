using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private  Transform shootPoint;
    [SerializeField] public int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(horizontal, vertical);
        velocity.Normalize();
        rb.velocity = velocity * speed;

        // fire
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(shootPrefab, shootPoint.position, transform.rotation);
        }

        
    }
    public void lossHealth(int damage){
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}
