using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{


    private int currentHealth;
    private int maxHealth = 100;

    //Barra de vida
    
    [SerializeField] Slider slider;

    private Animator animator;

    BoxCollider2D boxCollider2D;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        boxCollider2D = GetComponent<BoxCollider2D>();
        slider.value = currentHealth;

    }
    private void Update()
    {
        print(currentHealth);
        slider.value = currentHealth;
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
        GetComponentInChildren<Canvas>().enabled = false;
        Invoke("Destruir", 0.7f);
    }
    private void Destruir()
    {
        Destroy(gameObject);
    }

    

}
