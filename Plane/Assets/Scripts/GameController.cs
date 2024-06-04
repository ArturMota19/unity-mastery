using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector3 position;
    [SerializeField] private Text score;
    [SerializeField] private Text levelText;
    private float points = 0;
    [SerializeField] private float level = 1;
    [SerializeField] private float proxLevel = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        CreateObstacle();
        points += Time.deltaTime;

        score.text = "Points: " + Mathf.Round(points).ToString();
        UpLevel();

        
    }

    // procedure to create an obstacle
    private void CreateObstacle(){
        position = new Vector3(17, Random.Range(3.5f, 6f), 0);
        // create an obstacle every 1s
        timer -= Time.deltaTime;
        if(timer <= 0){
            Instantiate(obstacle, position, Quaternion.identity);
            timer = Random.Range(0.5f, 2f/level);
        }
    }
    private void UpLevel(){
        if(points >= proxLevel){
            level++;
            proxLevel *= 2;
            levelText.text = "Level: " + level.ToString();
        }
    }

    public float GetLevel(){
        return level;
    }
}
