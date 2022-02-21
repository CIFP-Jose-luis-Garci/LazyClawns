using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaMove : MonoBehaviour
{

    Animator animator;
    float speed;
    bool move;
    private PlayerMove playerHealth;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerMove>();
        speed = 2f;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BananaWalk") )
        {
            transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
           

    }
}
