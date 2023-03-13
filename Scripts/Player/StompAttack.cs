using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAttack : MonoBehaviour
{
    public Rigidbody2D PlayerRigid;
    public int Bounce;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerFeet")
        {
            //Debug.Log("GGGGGG");
            PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, 0f);
            PlayerRigid.AddForce(Vector2.up * Bounce);
            Destroy(transform.parent.gameObject);
        }
    }
}
