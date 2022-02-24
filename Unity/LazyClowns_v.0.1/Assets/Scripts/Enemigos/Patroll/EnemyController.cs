using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth = 100;
    
    
    

    private Animator animator;

    BoxCollider2D boxCollider2D;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = 100;
        boxCollider2D = GetComponent<BoxCollider2D>();
        
     
    }
    private void Update()
    {

        print(currentHealth);
    }

    //Recibir daño
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("hit");
        
        
        if (currentHealth <= 0)
        {
            EnemyDie();
            if(GetComponentInParent<EnemyPatrol>() != null)
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            if(GetComponent<AttackMelee>() != null)
            {
                GetComponent<AttackMelee>().enabled = false;
            }
            
            
            
        }
        else
        {
            currentHealth -= damage;

        }
    }


    //Muerte
    private void EnemyDie()
    {
       animator.SetBool("die", true);

        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Invoke("Destruir", 0.7f);
    }
    private void Destruir()
    {
        Destroy(gameObject);
    }

    

}
