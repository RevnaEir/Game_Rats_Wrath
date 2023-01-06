using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : MonoBehaviour
{
    /*
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        cooldownTimer += cooldownTimer.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        { 
             if (cooldownTimer >= attackCooldown)
            { 
                //Attack
            }
        }
    }



    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    */
}
