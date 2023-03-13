using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    private Vector3 RespawnPoint;
    public GameObject FallDetector;
    public PlayerHealth playerHealth;
    public int voidDMG;

    void Start()
    {
        RespawnPoint = transform.position;
    }

    void Update()
    {
        FallDetector.transform.position = new Vector2(transform.position.x, FallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = RespawnPoint;
            playerHealth.TakeDamage(voidDMG);

        }
        else if(collision.tag == "Checkpoint")
        {
            RespawnPoint = transform.position;
        }
    }
}
