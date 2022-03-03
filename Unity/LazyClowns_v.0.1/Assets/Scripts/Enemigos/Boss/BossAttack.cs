using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    
    [SerializeField] Transform[] instanciadores;
    [SerializeField] GameObject[] pinchos;
    Animator animator;
    
    

    // Update is called once per frame
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine("pinchosInstan");
    }

    IEnumerator pinchosInstan()
    {
        while (true)
        {
            int numA = Random.Range(0, 3);
            if (instanciadores[numA].name == "Pinchos1")
            {
                Instantiate(pinchos[numA], instanciadores[numA].TransformPoint(Vector3.zero), Quaternion.identity);
                animator.SetTrigger("meleeAttack");
            }  
            if (instanciadores[numA].name == "Pinchos2")
            {
                Instantiate(pinchos[numA], instanciadores[numA].TransformPoint(Vector3.zero), Quaternion.identity);
                animator.SetTrigger("meleeAttack");
            }  
            if (instanciadores[numA].name == "Pinchos3")
            {
                Instantiate(pinchos[numA], instanciadores[numA].TransformPoint(Vector3.zero), Quaternion.identity);
                animator.SetTrigger("meleeAttack");
            }  
            if (instanciadores[numA].name == "Pinchos4")
            {
                Instantiate(pinchos[numA], instanciadores[numA].TransformPoint(Vector3.zero), Quaternion.identity);
                animator.SetTrigger("meleeAttack");
            }  
           
           
            yield return new WaitForSeconds(1);
        }

       
    }

}
