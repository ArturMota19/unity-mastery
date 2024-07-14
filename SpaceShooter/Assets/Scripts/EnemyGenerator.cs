using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int points = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private int baseLevel = 100;
    private float spawnInterval = 0f;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private int enemyControlerQtd = 0;

    [SerializeField] private GameObject bossAnimation;
    [SerializeField] private GameObject boss;
    private bool bossAnimationController = false;
    private float bossTime = 5f;
    [SerializeField] private Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
        if(level < 10){
            EnemyGeneratorFunction();
        }else{
            GenerateBoss();
        }
    }

    public void GenerateBoss(){
        if(enemyControlerQtd <= 0 && bossTime > 0){
            bossTime -= Time.deltaTime;
        }
        if(!bossAnimationController && bossTime <= 0){
            GameObject animBoss = Instantiate(bossAnimation, Vector3.zero, transform.rotation);
            Destroy(animBoss, 6.3f);
            bossAnimationController = true;
        }
    }
    public void GetPoints(int points){
        this.points += points;
        if(this.points > baseLevel * level){
            level++;
            
        }
    }

    public void DecreaseEnemy(){
        enemyControlerQtd--;
    }
    private void EnemyGeneratorFunction(){
        if(spawnInterval > 0 && enemyControlerQtd <= 0){
            spawnInterval -= Time.deltaTime;
        }
        if(spawnInterval <= 0 && enemyControlerQtd <= 0)
        {
            // creating enemies
            int enemyQuantity = level * 4;
            
            while(enemyQuantity > enemyControlerQtd ){
                GameObject enemy;
                // the higher the level, the more chance of strong enemies coming
                float levelChance = Random.Range(0f, level);

                if(levelChance > 2f){
                    enemy = enemyPrefabs[1];
                }else{
                    enemy = enemyPrefabs[0];
                }
                Vector3 pos = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(6.5f, 10f), 0f);
                Instantiate(enemy, pos, transform.rotation);
                
                spawnInterval = spawnTime;
                enemyControlerQtd++;
            }
        }
    }
    
}
