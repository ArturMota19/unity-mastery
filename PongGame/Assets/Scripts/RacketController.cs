using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    // create vector3
    private Vector3 positionRacket;
    public float yPosition = 0.0f;
    public bool isPlayer1;

    // var to check if player 2 is AI
    public bool auto = false;

    // get ball position
    public Transform transformBall;
    void Start()
    {
        // init with current position (seted in Unity)
        positionRacket = transform.position;
    }

    void Update()
    {
        float speedDelta = 8f * Time.deltaTime;
        float limit = 3.5f;
        positionRacket.y = yPosition;
        

        // Change racket position based on user input
        // transform -> individual object's position, rotation, and scale
        // Transform -> class that contains position, rotation, and scale of an object
        transform.position = positionRacket;

        if(!auto){
            // Get user input
            if(!isPlayer1){
                if(Input.GetKey(KeyCode.UpArrow)){
                yPosition += speedDelta;
                }
                if(Input.GetKey(KeyCode.DownArrow)){
                    yPosition -= speedDelta;
                }
            }else{
                if(Input.GetKey(KeyCode.W)){
                yPosition += speedDelta;
            }
                if(Input.GetKey(KeyCode.S)){
                    yPosition -= speedDelta;
                }
            }

            if(yPosition < -limit){
                yPosition = -limit;
            }
            if(yPosition > limit){
                yPosition = limit;
            }
        }
        if(Input.GetKey(KeyCode.UpArrow)  || Input.GetKey(KeyCode.DownArrow)){
            auto = false;
        }
        // ball position
        if(!isPlayer1 && auto){
            yPosition = Mathf.Lerp(yPosition,transformBall.position.y, 0.02f);
        }
        if(yPosition < -limit){
            yPosition = -limit;
        }
        if(yPosition > limit){
            yPosition = limit;
        }

    }
}
