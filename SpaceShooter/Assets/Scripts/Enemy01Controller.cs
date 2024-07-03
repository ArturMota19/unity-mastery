using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Controller : MonoBehaviour
{

    // Get rigidbody2D component
    private Rigidbody2D rb;
    [SerializeField] private float speed = -1f;
    [SerializeField] private GameObject shootPrefab;
    private float shootTime = 1f;
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
        shootTime -= Time.deltaTime;
        if(shootTime <= 0 && GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            Instantiate(shootPrefab, transform.position, transform.rotation);
            shootTime = Random.Range(1.5f, 2f);
        }
        
    }
}
