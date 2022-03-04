using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactita : MonoBehaviour
{
    [SerializeField] BoxCollider2D colliderKunay, colliderDa�o;
    Animator animator;
    int da�o = 1000;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BoxCaida()
    {
        colliderKunay.enabled = true;
        colliderDa�o.enabled = false;
    }
    void BoxDa�o()
    {
        colliderKunay.enabled = true;
        colliderDa�o.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DisparoPlayer")
        {
            animator.SetTrigger("Caer");
            
        }
            
        else if(other.gameObject.tag =="Boss")
            other.GetComponent<BossCtr>().TakeDamage(da�o);
    }

}
