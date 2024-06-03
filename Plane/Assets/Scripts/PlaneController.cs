using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Input.GetKeyDown(KeyCode.B)){
            planeRB.velocity = Vector2.up * jumpForce;
        }
    }
}
