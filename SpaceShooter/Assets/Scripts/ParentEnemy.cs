using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentEnemy : MonoBehaviour
{

    // Get rigidbody2D component
    [SerializeField] protected float speed = -1f;
    [SerializeField] protected GameObject shootPrefab;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected  Transform shootPoint;
    [SerializeField] protected int health = 2;

    [SerializeField] protected GameObject impactShoot;
    [SerializeField] protected float shootTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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