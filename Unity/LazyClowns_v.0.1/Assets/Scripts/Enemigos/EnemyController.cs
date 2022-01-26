using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth = 100;
    float maxSpeed = 3f;
    public float speed = 1;
    

    //private Animator animator;

    BoxCollider2D boxCollider2D;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        currentHealth = 100;
        boxCollider2D = GetComponent<BoxCollider2D>();
     
    }
    private void Update()
    {
       
        
    }

    //Recibir daño
    public void TakeDamage(int damage)
    {
        //animator.SetTrigger("hit");
        
        
        if (currentHealth <= 0)
        {
            EnemyDie();
            
        }
        else
        {
            currentHealth -= damage;
            
        }
    }


    //Muerte
    private void EnemyDie()
    {
       //animator.SetBool("dead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    //Metodos para recibir daño
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AttackPoint")
        {
            speed = -2;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "AttackPoint")
        {
            speed = 1;

        }
        
    }

}
