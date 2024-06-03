using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour
{
    private Rigidbody2D planeRB;
    private float jumpForce = 5f;
    void Start()
    {
        planeRB = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        // jump with space
        GetUp();
        // limit velocity down
        LimitDown();
    }

    public void GetUp(){
        if(Input.GetKeyDown(KeyCode.Space)){
            planeRB.velocity = Vector2.up * jumpForce;
        }
    }
    public void LimitDown(){
        if(planeRB.velocity.y < -jumpForce){
            planeRB.velocity = Vector2.down * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameScene");
    }
}
