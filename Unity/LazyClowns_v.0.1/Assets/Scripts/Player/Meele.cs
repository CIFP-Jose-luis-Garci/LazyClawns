using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : MonoBehaviour
{
    InputSystem inputCr;
    private Animator animator;
    [SerializeField] GameObject hitBox;
    [SerializeField] Transform puntoDeAtaque;
    [SerializeField] Rigidbody2D rb2d;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputCr = new InputSystem();
        inputCr.Ataque.AtaqueBasico.started += _ => StartAttack();
        inputCr.Ataque.AtaqueBasico.canceled += _ => StopAttack();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartAttack()
    {
        if(animator.GetBool("timeattack")==false)
        {
            animator.SetBool("timeattack", true);
            animator.SetTrigger("attack");
     
        }
        
        
    }
    void StopAttack()
    {
        animator.SetBool("timeattack", false); 
        
    }
    void InstanciadorAtaqueMeele()
    {
        Instantiate(hitBox, puntoDeAtaque);
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
