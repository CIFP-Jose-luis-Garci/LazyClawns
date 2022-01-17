using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Animator animator;
    [SerializeField] Transform puntoDeAtaque;
    public float rangoAtaque = 0.5f;
    public LayerMask enemyLayers;
    public int daño = 30;

    InputSystem inputCr;
    bool ataque;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputCr = new InputSystem();
        //Correr
        inputCr.Ataque.AtaqueBasico.started += _ => { ataque = true; };
        inputCr.Ataque.AtaqueBasico.canceled += _ => { ataque = false; };
    }

    private void Start()
    {

    }

    private void Update()
    {
        
        if (ataque )
        {
            Attack();
            
            print("Atacado");
        }
        
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(puntoDeAtaque.position, rangoAtaque, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<EnemyController>().TakeDamage(daño);
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (puntoDeAtaque == null) return;
        Gizmos.DrawWireSphere(puntoDeAtaque.position, rangoAtaque);

    }
    private void OnEnable()//Importantisimo para el funcionamiento del nuevo input system
    {
        inputCr.Enable();
    }

    private void OnDisable()//Importantisimo para el funcionamiento del nuevo input system
    {
        inputCr.Disable();
    }
}
