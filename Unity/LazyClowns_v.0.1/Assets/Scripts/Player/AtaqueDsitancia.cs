using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDsitancia : MonoBehaviour
{
    //bool alive;//Ajustar cuando haya scrip grande

    [SerializeField] GameObject shotPoint;
    [SerializeField] GameObject [] arma;
    private Animator animator;

    InputSystem inputCr;

    bool ataque;

    private void Awake()
    {
        inputCr = new InputSystem();
        //Ataque a distancia
        inputCr.Ataque.AtaqueDsitancia.started += _ => { ataque = true; };
        inputCr.Ataque.AtaqueDsitancia.canceled += _ => { ataque = false; };
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        AtaqueDistancia();

    }

    void Instanciador()
    {
        int numA = Random.Range(0, arma.Length);
        
        Instantiate(arma[numA], shotPoint.transform.position,shotPoint.transform.rotation);
    }

    void AtaqueDistancia()
    {
        if (ataque)
        {
            animator.SetTrigger("AtaqueDistancia");
            animator.SetBool("timeattackDistance", true);

        }
        else
        {
            animator.SetBool("timeattackDistance", false);
        }
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
