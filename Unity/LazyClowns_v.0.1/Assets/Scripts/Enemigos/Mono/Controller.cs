using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Transform player;
    float rango;
    bool atacando = false;

    int vida = 150;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rango = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        Detectar();
    }

    void Detectar()
    {
        if(player.position.x <= rango )
        {
            animator.SetBool("EnRango", true);
           
        }
        else
        {
            animator.SetBool("EnRango", false);
        
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("hit");


        if (vida <= 0)
        {
            EnemyDie();

        }
        else
        {
            vida -= damage;

        }
    }

    private void EnemyDie()
    {
        animator.SetBool("die", true);
        this.enabled = false;
        Invoke("Destruir", 0.75f);
    }
    private void Destruir()
    {
        Destroy(gameObject);
    }


}
