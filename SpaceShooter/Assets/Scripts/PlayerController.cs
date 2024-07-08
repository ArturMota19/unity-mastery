using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private GameObject secondShootPrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private  Transform shootPoint;
    [SerializeField] private  Transform shootLeft;
    [SerializeField] private  Transform shootRight;
    [SerializeField] public int health = 5;
    [SerializeField] private float shootSpeed = 10f;
    [SerializeField] private float horizontalLimit = 8.3f;
    [SerializeField] private float verticalLimit = 4f;
    [SerializeField] private int shootLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        Moving();

        // fire
        Shooting();

    }

    private void Moving()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(horizontal, vertical);
        velocity.Normalize();
        rb.velocity = velocity * speed;

        // limit position
        float x = Mathf.Clamp(transform.position.x, -horizontalLimit, horizontalLimit);
        float y = Mathf.Clamp(transform.position.y, -verticalLimit, verticalLimit);
        transform.position = new Vector2(x, y);
    }

    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1") && shootLevel == 1)
        {
            WhichShoot(shootPrefab, shootPoint);
        }else if(Input.GetButtonDown("Fire1") && shootLevel == 2){
            WhichShoot(secondShootPrefab, shootLeft);
            WhichShoot(secondShootPrefab, shootRight);
        }else if(Input.GetButtonDown("Fire1") && shootLevel > 2){
            WhichShoot(shootPrefab, shootPoint);
            WhichShoot(secondShootPrefab, shootLeft);
            WhichShoot(secondShootPrefab, shootRight);
        }
    }

    private void WhichShoot(GameObject createdShoot, Transform shootPointParam){
        GameObject shoot = Instantiate(createdShoot, shootPointParam.position, transform.rotation);
        shoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, shootSpeed);
    }

    public void LossHealth(int damage){
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}
