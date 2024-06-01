using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    // create vector3
    private Vector3 positionRacket;
    public float yPosition = 0.0f;
    void Start()
    {
        // initial position of racket
        positionRacket.x = -8f;
    }

    void Update()
    {
        positionRacket.y = yPosition;
        

        // Change racket position based on user input
        // transform -> individual object's position, rotation, and scale
        // Transform -> class that contains position, rotation, and scale of an object
        transform.position = positionRacket;

        // Get user input
        if(Input.GetKey(KeyCode.UpArrow) && yPosition < 3.5f){
            yPosition += 5f * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow) && yPosition > -3.5f){
            yPosition -= 5f * Time.deltaTime;
        }

    }
}
