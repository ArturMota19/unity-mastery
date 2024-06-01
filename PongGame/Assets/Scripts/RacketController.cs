using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    // create vector3
    private Vector3 positionRacket;
    public float yPosition = 0.0f;
    public bool isPlayer1;
    void Start()
    {
        // init with current position (seted in Unity)
        positionRacket = transform.position;
    }

    void Update()
    {
        float speedDelta = 5f * Time.deltaTime;
        float limit = 3.5f;
        positionRacket.y = yPosition;
        

        // Change racket position based on user input
        // transform -> individual object's position, rotation, and scale
        // Transform -> class that contains position, rotation, and scale of an object
        transform.position = positionRacket;

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
}
