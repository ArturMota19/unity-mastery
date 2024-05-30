using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello World - Debug Log");
        Debug.LogWarning("Hello World - Warning Log");
        Debug.LogError("Hello World - Error Log");

        int number = 50;
        string name = "John Doe";
        float pi = 3.14f;
        Debug.Log("Number: " + number + ", Name: " + name + ", PI: " + pi);
    }

    void Update()
    {
        
    }
}
