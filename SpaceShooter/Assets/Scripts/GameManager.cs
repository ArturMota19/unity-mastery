using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private void Awake() {
        // Ensure only one GameManager exists
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        // Ensure only one GameManager exists
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FirstScene(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
    IEnumerator StartTime(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
    

    // Initialize scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartGame(){
        StartCoroutine(StartTime());
    
    }
    public void InitScreen(){
        StartCoroutine(FirstScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
