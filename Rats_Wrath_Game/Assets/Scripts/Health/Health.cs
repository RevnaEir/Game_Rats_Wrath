using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

   [SerializeField] private float startingHealth;
   public float currentHealth { get; private set; } //Made it safe public (only set into TakeDamage void)

    private Animator anim;
    private bool dead;


   private void Awake()
   {
    currentHealth = startingHealth;
    anim = GetComponent<Animator>();
   }

   public void TakeDamage(float _damage)
   {
    currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
    if (currentHealth > 0)
    {
        //player hurt
        anim.SetTrigger("hurt");
        //iframes
    }
    else
    {
        if (!dead)
        {
        //player dead
        anim.SetTrigger("die");
        //GetComponent<PlayerMovement>().enable = false;
        dead = true;
        }
        
    }
   }


    ///* Testing Health
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
   // */
}
