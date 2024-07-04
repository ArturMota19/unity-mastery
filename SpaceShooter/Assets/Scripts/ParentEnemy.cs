using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
    [SerializeField] protected float shootSpeed = -5f;
    [SerializeField] protected float yMax = 2f;

    protected bool hasMoved = false;

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
    public void Shooting()
    {
        shootTime -= Time.deltaTime;
        if (shootTime <= 0 && GetComponentInChildren<SpriteRenderer>().isVisible && GameObject.FindGameObjectWithTag("Player01") != null)
        {
            var shoot = Instantiate(shootPrefab, shootPoint.position, transform.rotation);
            shoot.GetComponent<Rigidbody2D>().velocity = new UnityEngine.Vector2(0f, shootSpeed);
            shootTime = Random.Range(1f, 1.75f);
        }
    }

    public void GuidedShooting()
    {
        shootTime -= Time.deltaTime;
        if (shootTime <= 0 && GetComponentInChildren<SpriteRenderer>().isVisible && GameObject.FindGameObjectWithTag("Player01") != null)
        {
            var player = GameObject.FindGameObjectWithTag("Player01");
            var shoot = Instantiate(shootPrefab, shootPoint.position, transform.rotation);
            var direction = (player.transform.position - shoot.transform.position).normalized;
            direction.Normalize();

            shoot.GetComponent<Rigidbody2D>().velocity = direction * shootSpeed ;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            shoot.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, angle + 90);
            shootTime = Random.Range(1f, 1.75f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("EnemyDestroyer"))
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player01"))
        {
            other.gameObject.GetComponent<PlayerController>().lossHealth(1);
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}