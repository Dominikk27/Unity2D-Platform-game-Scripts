using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public bool mustCover;
    public bool mustTurn;
    public float DealDMG;
    public int walkSpeed;

    public bool isDamaged;
    public float PlayerHitCooldown;
    public int EnemyHealth;

    public Rigidbody2D EnemyRigidBody;
    public Transform GroundPos;
    public LayerMask GroundLayer;

    public Rigidbody2D PlayerRigidBody;
    public PlayerHealth playerHealth;

    void Start()
    {
        mustCover = true;
        mustTurn = false;
        isDamaged = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(DealDMG);
            StartCoroutine(DMG_Cooldown());
        }


       /* if(collision.gameObject.tag == "Bullet")
        {
            EnemyTakeDMG();
        }*/
    }

    /*void EnemyTakeDMG(int TakeDMG)
    {
        EnemyHealth -= TakeDMG

        if(EnemyHealth < 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }*/

    void Update()
    {
        EnemyRigidBody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, EnemyRigidBody.velocity.y);
        mustTurn = !Physics2D.OverlapCircle(GroundPos.position, 0.1f, GroundLayer);
        if(mustTurn && mustCover)
        {
            Flip();
        }
    }

    void Cover()
    {
        //EnemyRigidBody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, EnemyRigidBody.velocity.y);
        //mustTurn = !Physics2D.OverlapCircle(GroundPos.position, 0.1f, GroundLayer);
        //if(mustTurn){
            
            //Debug.Log("I AM ON FLOOR");
            //Flip();
        //}
    }

    void Flip()
    {
       mustTurn = false;
       mustCover = false;
       transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); 
       walkSpeed *= -1;
       mustCover = true;
    }

    IEnumerator DMG_Cooldown()
    {
        isDamaged = false;
        yield return new WaitForSeconds(PlayerHitCooldown);
    }
}
