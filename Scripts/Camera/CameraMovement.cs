using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float FollowSpeed = 2f;
    public float Y_Offset = 1f;
    public PlayerHealth playerHealth;


    void Start()
    {
        
    }

    void Update()
    {
        if(playerHealth.health > 0)
        {
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + Y_Offset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        }
        else
        {

        }
    }
}
