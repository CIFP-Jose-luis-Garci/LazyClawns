using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCtr : MonoBehaviour

{
     int maxHealth = 10000;

    public int currentHealth;

    [SerializeField] public Slider slider;

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
        slider.value = currentHealth;

}

//Recibir daño
public void TakeDamage(int damage)
{
    animator.SetTrigger("Daño");

    if (currentHealth >= 0)
    {
        currentHealth -= damage;
            if (currentHealth <= 0)
            {
                EnemyDie();

            }

        }
}


//Muerte
private void EnemyDie()
{
    animator.SetBool("Muerto", true);
    
    //GetComponent<Collider2D>().enabled = false;
    this.enabled = false;
    Invoke("Destruir", 4f);
}
private void Destruir()
{
    Destroy(gameObject);
}

    

}
