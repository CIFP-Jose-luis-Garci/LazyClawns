using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth = 100;
    //private Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        currentHealth = 100;
    }
    private void Update()
    {
        //print(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        //animator.SetTrigger("hit");
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            EnemyDie();
            print("MUERTO");
        }
    }

    private void EnemyDie()
    {
       //animator.SetBool("dead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
