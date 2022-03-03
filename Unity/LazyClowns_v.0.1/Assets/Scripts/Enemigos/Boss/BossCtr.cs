using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtr : MonoBehaviour

{
     int maxHealth = 10000;

    private int currentHealth ;




private Animator animator;

BoxCollider2D boxCollider2D;

private void Start()
{
    animator = GetComponent<Animator>();
    currentHealth = maxHealth;
    boxCollider2D = GetComponent<BoxCollider2D>();


}
private void Update()
{

    print(currentHealth);
}

//Recibir daño
public void TakeDamage(int damage)
{
    animator.SetTrigger("Daño");


    if (currentHealth <= 0)
    {
        EnemyDie();
        if (GetComponentInParent<EnemyPatrol>() != null)
        {
            GetComponentInParent<EnemyPatrol>().enabled = false;
        }
        if (GetComponent<AttackMelee>() != null)
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
    animator.SetBool("Muerto", true);

    //GetComponent<Collider2D>().enabled = false;
    this.enabled = false;
    Invoke("Destruir", 0.75f);
}
private void Destruir()
{
    Destroy(gameObject);
}

    

}
