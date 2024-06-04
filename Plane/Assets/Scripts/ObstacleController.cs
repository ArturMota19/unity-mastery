using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject obstacle;

    [SerializeField] private Controller gameController;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(obstacle, 5f);
        gameController = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;

        speed = 10f + gameController.GetLevel();
    }
}
