using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlaneController : MonoBehaviour
{
    private Rigidbody2D planeRB;
    private float jumpForce = 5f;
    [SerializeField] private GameObject puf;
        private Vector3 positionMocked = new Vector3(0, 0, 0);
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
        // limit screen
        LimitScreen();
    }

    public void GetUp(){
        if(Input.GetKeyDown(KeyCode.Space)){
            planeRB.velocity = Vector2.up * jumpForce;
            positionMocked = new Vector3(transform.position.x - 1f, transform.position.y, -230);
            // save an instance of puf in a variable
            GameObject pufInstance = Instantiate(puf, positionMocked, Quaternion.identity);
            Destroy(pufInstance, 0.9f);
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
    private void LimitScreen(){
        if(transform.position.y > 4.5f || transform.position.y < -4.5f){
            SceneManager.LoadScene("GameScene");
        }
    }
}
