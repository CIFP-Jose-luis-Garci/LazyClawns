using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth = 100;
    float maxSpeed = 3f;
    public float speed = 1;
    [SerializeField] Rigidbody2D rb2D;

    //private Animator animator;

    BoxCollider2D boxCollider2D;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        currentHealth = 100;
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        

    }
    private void Update()
    {
        print(currentHealth);
        
    }
    private void FixedUpdate()
    {
        Mover();
    }

    public void TakeDamage(int damage)
    {
        //animator.SetTrigger("hit");
        
        
        if (currentHealth <= 0)
        {
            EnemyDie();
            print("MUERTO");
        }
        else
        {
            currentHealth -= damage;
            
        }
    }
    void Mover()
    {
        rb2D.velocity = new Vector2(-1 * maxSpeed, rb2D.velocity.y);   //Mantener velocidad en el aire y moverse sin que afecte(Movimiento en el aire)
        speed = rb2D.velocity.x;
    }

    private void EnemyDie()
    {
       //animator.SetBool("dead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
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
