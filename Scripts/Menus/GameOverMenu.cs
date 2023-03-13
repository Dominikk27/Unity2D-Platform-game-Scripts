using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject pauseMenu;
    public GameObject GameOver;
    public GameObject GameCanvs;

    public static bool isDead;

    void Start()
    {
        Time.timeScale = 1f;
        isDead = false;
        GameOver.SetActive(false);
        pauseMenu.SetActive(false);
        GameCanvs.SetActive(true);
    }

    void Update()
    {
        if(playerHealth.health <= 0)
        {
            gameOver();
            if(isDead)
            {
                Time.timeScale = 0f;
                GameOver.SetActive(true);
                pauseMenu.SetActive(false);
                GameCanvs.SetActive(false);
            }
            else
            {
                Time.timeScale = 1f;
                GameOver.SetActive(false);
                pauseMenu.SetActive(false);
                GameCanvs.SetActive(true);
            }
        }
    }

    public void gameOver()
    {
        isDead = true;
        GameOver.SetActive(true);
        pauseMenu.SetActive(false);
        GameCanvs.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
