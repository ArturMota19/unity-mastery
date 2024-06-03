using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(obstacle, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }
}
