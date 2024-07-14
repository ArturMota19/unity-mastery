using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private void Awake() {
        //only one gm
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if(objs.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FirstScene(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    
    }
    // init scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void InitScreen(){
        StartCoroutine(FirstScene());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
