using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_ : MonoBehaviour
{
    //private bool isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
        
    }

    public void QuitGame()
    {
        //EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
