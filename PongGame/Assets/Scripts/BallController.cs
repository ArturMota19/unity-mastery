using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public Rigidbody2D ballRB;
    public Vector2 ballVelocity;
    private float speed = 10f;
    public AudioClip boing;

    public Transform cameraTransform;
    public float timeDelay = 1f;
    public bool isPlaying = false;

    
    void Start()
    {   
    }

    void Update()
    {
        // ball w/ delay
        timeDelay -= Time.deltaTime;

        if(timeDelay <= 0 && !isPlaying){
            isPlaying = true;
            // random to generate 1 or -1
            float range = Random.Range(0, 2) == 0 ? -1 : 1;

            ballVelocity.x = range * speed; // ball goes to the left or right
            ballVelocity.y = range * speed; // ball goes up or down
            ballRB.velocity = ballVelocity;
        }
        if(
            transform.position.x > 8.2 || transform.position.x < -8.2){
            SceneManager.LoadScene("Pong");
        }
        
    }

    // sound effect
    private void OnCollisionEnter2D(Collision2D other) {
        AudioSource.PlayClipAtPoint(boing, cameraTransform.position);
    }
}
