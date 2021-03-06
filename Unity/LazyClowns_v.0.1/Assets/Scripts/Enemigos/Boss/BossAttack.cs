using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    
    [SerializeField] GameObject[] animaciones;
    
    Animator animator;
    Animator pinchosAnime;

    public float intervalo;

    // Update is called once per frame
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine("pinchosInstan");
        intervalo = 4;
    }

    IEnumerator pinchosInstan()
    {
        while (true)
        {
            int numA = Random.Range(0, animaciones.Length);
            pinchosAnime = animaciones[numA].GetComponent<Animator>();
            pinchosAnime.SetTrigger("Ataque");

            animator.SetTrigger("meleeAttack");
            yield return new WaitForSeconds(intervalo);
        }

       
    }

}
