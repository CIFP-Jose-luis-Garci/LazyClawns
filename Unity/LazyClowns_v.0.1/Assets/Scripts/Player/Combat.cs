using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
   // private Animator animator;
    [SerializeField] Transform puntoDeAtaque;
    public float rangoAtaque = 0.5f;
    public LayerMask enemyLayers;
    public int da�o = 30;

    InputSystem inputCr;
    bool ataque;


    private void Awake()
    {
        //animator = GetComponent<Animator>();
        //Correr
        //inputCr.Ataque.AtaqueBasico.started += _ => { ataque = true; };
        //inputCr.Ataque.AtaqueBasico.canceled += _ => { ataque = false; };
    }

    private void Start()
    {

    }

    private void Update()
    {
        
        if (ataque /*&& siguienteAtaque >= tiempoAtaque*/)
        {
            Attack();
            
            print("Atacado");
        }
        
    }

    private void Attack()
    {
        //animator.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(puntoDeAtaque.position, rangoAtaque, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<EnemyController>().TakeDamage(da�o);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (puntoDeAtaque == null) return;
        Gizmos.DrawWireSphere(puntoDeAtaque.position, rangoAtaque);

    }
}
