using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : ParentEnemy
{
    [Header("Basic Infos")]
    [SerializeField] private int bossState = 0; // 0, 1, 2
    [SerializeField] private Rigidbody2D rb;
    private bool direction = true; // true = right, false = left
    // Start is called before the first frame update
    [SerializeField] private float limit = 6f;

    [Header("Shoots")]
    [SerializeField] private Transform firstShootPos;
    [SerializeField] private Transform firstShootPos2;
    [SerializeField] private Transform secondShootPos;
    [SerializeField] private GameObject firstShoot;
    [SerializeField] private GameObject secondShoot;
    [SerializeField] private int[] states = {0, 1, 2};
    [SerializeField] float changeStatesAwait = 5f;
    [SerializeField] private Image bossLife;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bossLife.fillAmount = (float)health / 600;
        bossLife.color = Color.Lerp(Color.red, Color.green, (float)health / 600);
        ChangeStates();
        switch(bossState)
        {
            case 0:
                FirstState();
                break;
            case 1:
                SecondState();
                break;
            case 2:
                ThirdState();
                break;
        }
    }

    private void FirstState(){
        if(shootTime <= 0){
            FirstShoot();
            shootTime = .5f;
        }else{
            shootTime -= Time.deltaTime;
        }

        rb.velocity = new Vector2(speed, 0);
        if(direction){
            rb.velocity = new Vector2(speed, 0);
        }else if(!direction){
            rb.velocity = new Vector2(-speed, 0);
        }

        if(transform.position.x >= limit){
            direction = false;
        }else if(transform.position.x <= -limit){
            direction = true;
        }
    }
    private void SecondState(){
        rb.velocity = new Vector2(0, 0);
        if(shootTime <= 0){
            SecondShoot();
            shootTime = .5f;
        }else{
            shootTime -= Time.deltaTime;
        }
    }

    private void ThirdState(){
        SecondState();
        FirstState();
    }

    private void FirstShoot(){
        AudioSource.PlayClipAtPoint(soundLaser, UnityEngine.Vector2.zero);
        GameObject shootPos1 = Instantiate(firstShoot, firstShootPos.position, Quaternion.identity);
        shootPos1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, shootSpeed);
        GameObject shootPos2 = Instantiate(firstShoot, firstShootPos2.position, Quaternion.identity);
        shootPos2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, shootSpeed);
    }
    private void SecondShoot(){
        // Instantiate(secondShoot, secondShootPos.position, Quaternion.identity);    
        GuidedBossShooting(secondShoot, secondShootPos.position);
    }

    private void ChangeStates(){
        if(changeStatesAwait <= 0){
            bossState = states[Random.Range(0, states.Length)]; 
            changeStatesAwait = 5f;
        }else{
            changeStatesAwait -= Time.deltaTime;
        }
        
    }

}

