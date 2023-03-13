using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI PlayerScore, PlayerBullets;
    public int Score;

    // AMMO REMOVED
    //public int Bullets;
    //public int AmmoBoxBullets;

    void Start()
    {
        Score = 0;
        PlayerScore.text = ": " + Score;
        // PlayerBullets.text = ": " + Bullets;
    }
    
    void FixedUpdate(){
        PlayerScore.text = ": " + Score;
        // PlayerBullets.text = ": " + Bullets;
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fuel"){
            Score++;
            Destroy(collision.gameObject);
        }

        /*if (collision.tag == "Ammo"){
            Debug.Log("WE THERE");
            Bullets = Bullets + AmmoBoxBullets;
            Destroy(collision.gameObject);
        }*/
        //PlayerScore.text = "Fuel: " + Score;
    }
}
