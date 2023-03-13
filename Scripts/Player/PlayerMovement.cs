using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed;
    private float SideMove;

    public bool isGrounded;
    public int JumpPower;
    public float FallMultiplier;
    Vector2 Gravity;
    public Transform GroundCheckColl;
    public LayerMask GroundLayer;

    private Animator anim;
    private Vector3 localScale;
    private Rigidbody2D RigidBody;


    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Gravity = new Vector2(0, -Physics2D.gravity.y);
    }


    void Update()
    {
        SideMove = Input.GetAxis("Horizontal");
        RigidBody.velocity = new Vector2(MoveSpeed* SideMove, RigidBody.velocity.y);

        /*SIDE MOVE + TRANSFORMATION + ANIMATION*/
        if(SideMove > 0)
        {
            //transform.Roatate(0, 180, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(SideMove < 0)
        {
            //transform.Roatate(0, 180, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(SideMove != 0){
            //RigidBody.AddForce(new Vector2)
            anim.SetBool("isRunning", true);
        }
        else if(SideMove == 0){
            anim.SetBool("isRunning", false);
        }
        /*SIDE MOVE + TRANSFORMATION + ANIMATION*/
        isGrounded = Physics2D.OverlapCapsule(GroundCheckColl.position, new Vector2(0.5f, 0.3f),CapsuleDirection2D.Horizontal, 0, GroundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            RigidBody.velocity = new Vector2(RigidBody.velocity.x, JumpPower);
        }

        /*GRAVITY MULTIPLY*/
        if(RigidBody.velocity.y < 0)
        {
           RigidBody.velocity -= Gravity * FallMultiplier * Time.deltaTime; 
        }
        /*GRAVITY MULTIPLY*/

    }
}


