using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaMove : MonoBehaviour
{

    Animator animator;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BananaWalk"))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y);
        }
    }
}
