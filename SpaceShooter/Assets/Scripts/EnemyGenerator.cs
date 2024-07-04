using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    private int points = 0;
    private int level = 1;
    private float spawnInterval = 0f;
    [SerializeField] private float spawnTime = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyGeneratorFunction();
    }

    private void EnemyGeneratorFunction(){
        spawnInterval -= Time.deltaTime;
        if(spawnInterval <= 0)
        {
            Vector3 pos = new Vector3(Random.Range(-8.5f, 8.5f), 6.5f, 0f);
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], pos, transform.rotation);
            
            spawnInterval = spawnTime;
        }
    }
}
