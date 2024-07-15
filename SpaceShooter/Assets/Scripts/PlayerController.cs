using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject shield;
    [SerializeField] private int shieldNumber = 3;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text shieldText;
    [SerializeField] private Text gameOv;
    [SerializeField] private AudioClip soundLaser;
    [SerializeField] private AudioClip soundShieldUp;
    [SerializeField] private AudioClip soundShieldDown;
    private float shieldTime = 0f;
    private GameObject actualShield;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeUi();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeUi();
        // movement
        Moving();

        // fire
        Shooting();

        // shield
        ShieldCreator();

    }

    private void ChangeUi(){
        if(GameObject.FindGameObjectWithTag("Player01") != null){
            lifeText.text = health.ToString();
        }else{
            lifeText.text = "Game Over";
        }
        shieldText.text = shieldNumber.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PowerUp")){
            Destroy(other.gameObject);
            if(shootLevel < 3){
                shootLevel++;
            }
        }
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
            AudioSource.PlayClipAtPoint(soundLaser, Vector3.zero);
            WhichShoot(shootPrefab, shootPoint);
        }else if(Input.GetButtonDown("Fire1") && shootLevel == 2){
            AudioSource.PlayClipAtPoint(soundLaser, Vector3.zero);
            WhichShoot(secondShootPrefab, shootLeft);
            WhichShoot(secondShootPrefab, shootRight);
        }else if(Input.GetButtonDown("Fire1") && shootLevel > 2){
            AudioSource.PlayClipAtPoint(soundLaser, Vector3.zero);
            WhichShoot(shootPrefab, shootPoint);
            WhichShoot(secondShootPrefab, shootLeft);
            WhichShoot(secondShootPrefab, shootRight);
        }
    }

    private void ShieldCreator(){
        if(Input.GetButtonDown("Shield") && !actualShield){
            if(shieldNumber > 0 && shieldNumber <= 3){
                AudioSource.PlayClipAtPoint(soundShieldUp, Vector3.zero);
                actualShield = Instantiate(shield, transform.position, transform.rotation);
                shieldNumber--;
            }
        }
        if(actualShield){
            actualShield.transform.position = transform.position;

            shieldTime += Time.deltaTime;
            if(shieldTime >= 5.8f){
                AudioSource.PlayClipAtPoint(soundShieldDown, Vector3.zero);
                shieldTime = 0f;
                Destroy(actualShield);
            }


        }
    }

    public void DestroyShield(){
        Destroy(actualShield);
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
            gameOv.text = "Game Over";
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            var gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            if(gm){
                gm.RestartGame();
            }

        }
    }

    IEnumerator WinnedTimmereND(){
        yield return new WaitForSeconds(15f);
        Application.Quit();
        
        
    }
    IEnumerator WinnedTimmer(){
        yield return new WaitForSeconds(7f);
        gameOv.text = "You Win! Tks for playing!";
        //green text
        gameOv.color = new Color(0, 255, 0);
        
        
    }

    public void WinGame(){
        StartCoroutine(WinnedTimmer());
        StartCoroutine(WinnedTimmereND());
    }

    public int GetShieldNumber(){
        return shieldNumber;
    }
}
