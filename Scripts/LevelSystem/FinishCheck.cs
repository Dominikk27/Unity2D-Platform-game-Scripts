using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCheck : MonoBehaviour
{
    public static bool FuelCollected;
    public ScoreScript playerScore;

    public int NeededScore;

    void Start()
    {
        FuelCollected = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore.Score >= NeededScore)
        {
            FuelCollected = true; 
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(FuelCollected)
        {
            Debug.Log("LevelDone");
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("ReachedLevel", nextLevel);
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            Debug.Log("U NEED TO COLLECT " + (NeededScore - playerScore.Score));
        }
    }
}
