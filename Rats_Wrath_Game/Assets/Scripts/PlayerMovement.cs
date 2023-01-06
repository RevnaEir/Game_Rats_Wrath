using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    //Flip
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float direction = 1;
    private float magnitude = 1;
    //Can make public void, not SerializeField (But SF is better)
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;

    //To not have to change multiple booliens in the animator
    private enum MovementState { idle, running, jumping, falling, attack }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        //Flip
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Flip();
        dirX =Input.GetAxis("Horizontal");

        if (!isAttacking)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

private void UpdateAnimationState()
{
    MovementState state;
    
    if (dirX > 0f)
    {
        state = MovementState.running;
        sprite.flipX = false;
        direction = 1;
    }
    else if (dirX < 0f)
    {
        state = MovementState.running;
        sprite.flipX = true;
        direction = -1;
    }
    else
    {
        state = MovementState.idle;
    }

    // If attacking triggered. stade idle false;

    if (rb.velocity.y > .1f)
    {
        state = MovementState.jumping;
    }

    else if (rb.velocity.y < -1f)
    {
        state = MovementState.falling;
    }
   
    // Check attack input
    if (Input.GetMouseButtonDown(0) && !isAttacking)
    {
        isAttacking = true;
        state = MovementState.attack;
    }

    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle"))
    {
        isAttacking = false;
    }

    anim.SetInteger("state",(int)state);

}

    private bool isAttacking = false;

    private void Flip()
    {
        if(direction == 1)
        {
            Vector3 localScale = transform.localScale;
            if(magnitude < 1)
            {
                magnitude = magnitude + 1f;
            }
            localScale.x = magnitude;
            transform.localScale = localScale;
        }
        if(direction == -1)
        {
            Vector3 localScale = transform.localScale;
            if(magnitude > -1)
            {
                magnitude = magnitude - 1f;
            }
            localScale.x = magnitude;
            transform.localScale = localScale;
        }
    }

        private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    //Moving with platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            // Set the player's parent to the platform
            transform.parent = collision.transform;
        }
    }
    //Unparenting
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }



}