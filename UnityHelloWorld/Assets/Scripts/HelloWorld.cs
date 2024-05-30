using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public string publicVariable = "Public Variable";
    private string privateVariable = "Private Variable";
    string global = "Global Variable";
    void Start()
    {
        Debug.Log("Hello World - Debug Log");
        Debug.LogWarning("Hello World - Warning Log");
        Debug.LogError("Hello World - Error Log");

        int number = 50;
        string name = "John Doe";
        float pi = 3.14f;
        Debug.Log("Number: " + number + ", Name: " + name + ", PI: " + pi);

        // Conditional functions
        if (number > 10)
        {
            Debug.Log("Number is greater than 10");
        }
        else if (number < 10)
        {
            Debug.Log("Number is less than 10");
        }
        else
        {
            Debug.Log("Number is equal to 10");
        }
    }

    void Update()
    {
    }
}
