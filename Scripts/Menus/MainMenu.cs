using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void LoadLevel(int index){
        SceneManager.LoadScene(index);
        Time.timeScale = 1f; 
    }

    public void QuitGame(){
        Application.Quit();
    }
}