using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDsitancia : MonoBehaviour
{
    //bool alive;//Ajustar cuando haya scrip grande

    [SerializeField] GameObject shotPoint;
    [SerializeField] GameObject [] arma;
    [SerializeField] GameObject bolaFuego, bolaRayo, bolaAgua;
    GameObject objeto;
    private Animator animator;
    private PlayerMove spriteRender;
    int numSkin;
    InputSystem inputCr;

    bool ataque;

    private void Awake()
    {
        inputCr = new InputSystem();
        //Ataque a distancia
        inputCr.Ataque.AtaqueDsitancia.started += _ => AtaqueDistanciaInicio();
        inputCr.Ataque.AtaqueDsitancia.canceled += _ => AtaqueDistanciaFinal();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        numSkin = PlayerMove.skinSelected;
    }

    // Update is called once per frame
    void Update()
    {

        numSkin = PlayerMove.skinSelected;

    }

    void Instanciador()
    {
        if (PauseManager.paused || PauseManager.inventario)
            return;
        
        if (numSkin == 0)
        {
            int numA = Random.Range(0, arma.Length);
            objeto = arma[numA];
        }
        if (numSkin == 1)
        {
            objeto = bolaAgua;
        }
        if (numSkin == 2)
        {
            objeto = bolaFuego;
        }
        if (numSkin == 3)
        {
            objeto= bolaRayo;
        }

        GameObject Shuriken = Instantiate(objeto, shotPoint.transform.position,shotPoint.transform.rotation) as GameObject;
    }

    void AtaqueDistanciaInicio()
    {
        if (PauseManager.paused || PauseManager.inventario)
            return;

        animator.SetTrigger("AtaqueDistancia");
            animator.SetBool("timeattackDistance", true);
       
    }
    void AtaqueDistanciaFinal()
    {
        animator.SetBool("timeattackDistance", false);
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
