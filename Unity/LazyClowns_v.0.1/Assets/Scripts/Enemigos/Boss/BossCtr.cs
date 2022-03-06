using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossCtr : MonoBehaviour

{
    int maxHealth = 10000;

    public int currentHealth;

    [SerializeField] public Slider slider;

    private Animator animator;
    BossAttack bossAttack;
    BoxCollider2D boxCollider2D;

private void Start()
{
    animator = GetComponent<Animator>();
    currentHealth = maxHealth;
    boxCollider2D = GetComponent<BoxCollider2D>();
    slider.value = currentHealth;
    bossAttack = GetComponent<BossAttack>();
    }
private void Update()
{
        slider.value = currentHealth;
        VelocidadAtaque();
        print(bossAttack.intervalo);
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

void VelocidadAtaque()
    {
        if(currentHealth == 7000)
        {
            bossAttack.intervalo = 5;
        }
        else if (currentHealth == 4000)
        {
            bossAttack.intervalo = 4;
        }
        else if(currentHealth == 1000)
        {
            bossAttack.intervalo = 3;
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
        SceneManager.LoadScene(8);
    }

    

}
