using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Transform player;
    float rango;
    bool atacando = false;



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






}
