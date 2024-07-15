using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
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
    [SerializeField] protected int pointsGived;
    [SerializeField] protected GameObject powerUp;
    [SerializeField] protected float itemRate = 0f;
    [SerializeField] protected bool isBoss = false;
    [SerializeField] protected AudioClip soundLaser;
    protected bool hasMoved = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LossHealth(int damage){
        if(transform.position.y < 5f){
            health -= damage;
            if(health <= 0)
            {
                if(isBoss){
                    var player = GameObject.FindGameObjectWithTag("Player01");
                    var playerController = player.GetComponent<PlayerController>();
                    playerController.WinGame();
                }

                
                Destroy(gameObject);
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                var generator = FindObjectOfType<EnemyGenerator>();
                generator.GetPoints(pointsGived);
                if(Random.Range(0f, 1f) > itemRate && powerUp){
                    GameObject powerUpInst = Instantiate(powerUp, transform.position, transform.rotation);
                    var dir = new UnityEngine.Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
                    powerUpInst.GetComponent<Rigidbody2D>().velocity = dir * 2f;
                    Destroy(powerUpInst, 3f);
                }


                
            }
        }
    }
    public void Shooting()
    {
        shootTime -= Time.deltaTime;
        if (shootTime <= 0 && GetComponentInChildren<SpriteRenderer>().isVisible && GameObject.FindGameObjectWithTag("Player01") != null)
        {
            AudioSource.PlayClipAtPoint(soundLaser, UnityEngine.Vector2.zero);
            var shoot = Instantiate(shootPrefab, shootPoint.position, transform.rotation);
            shoot.GetComponent<Rigidbody2D>().velocity = new UnityEngine.Vector2(0f, shootSpeed);
            shootTime = Random.Range(1f, 3f);
        }
    }

    public void GuidedShooting()
    {
        shootTime -= Time.deltaTime;
        if (shootTime <= 0 && GetComponentInChildren<SpriteRenderer>().isVisible && GameObject.FindGameObjectWithTag("Player01") != null)
        {
            AudioSource.PlayClipAtPoint(soundLaser, UnityEngine.Vector2.zero);
            var player = GameObject.FindGameObjectWithTag("Player01");
            var shoot = Instantiate(shootPrefab, shootPoint.position, transform.rotation);
            var direction = (player.transform.position - shoot.transform.position).normalized;
            direction.Normalize();

            shoot.GetComponent<Rigidbody2D>().velocity = direction * shootSpeed ;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            shoot.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, angle + 90);
            shootTime = Random.Range(8f, 12f);
        }
    }

    public void GuidedBossShooting(GameObject shootBoss, UnityEngine.Vector3 shootBossPoint){
        shootTime -= Time.deltaTime;
        if (GetComponentInChildren<SpriteRenderer>().isVisible && GameObject.FindGameObjectWithTag("Player01") != null)
        {
            AudioSource.PlayClipAtPoint(soundLaser, UnityEngine.Vector2.zero);
            var player = GameObject.FindGameObjectWithTag("Player01");
            var shoot = Instantiate(shootBoss, shootBossPoint, transform.rotation);
            var direction = (player.transform.position - shoot.transform.position).normalized;
            direction.Normalize();

            shoot.GetComponent<Rigidbody2D>().velocity = direction * -shootSpeed ;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            shoot.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, angle + 90);
            shootTime = Random.Range(6f, 10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("EnemyDestroyer"))
        {
            if(isBoss){
                var player = GameObject.FindGameObjectWithTag("Player01");
                var playerController = player.GetComponent<PlayerController>();
                playerController.DestroyShield();
            }else{
                Destroy(gameObject);
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player01"))
        {
            if(isBoss){
                other.gameObject.GetComponent<PlayerController>().LossHealth(100);
            }else{
                other.gameObject.GetComponent<PlayerController>().LossHealth(1);
                Destroy(gameObject);
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
        }
    }

    private void OnDestroy() {
        var generator = FindObjectOfType<EnemyGenerator>();
        
        if(generator){
            generator.DecreaseEnemy();
        }
    }
}