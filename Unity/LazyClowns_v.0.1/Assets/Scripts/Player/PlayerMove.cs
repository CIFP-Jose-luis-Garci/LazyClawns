using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //Variables del input Sistem
    InputSystem inputCr;
    float movimiento;
    bool saltando;
    bool correr;
    bool saltar;
    

    public float speed;
    Rigidbody2D rb2D;
    Animator animator;


    bool alive;
    float desplX;
    float maxSpeed;
    float jumpForce;
    private bool facingRight = true;
    [SerializeField] float distanciaSuelo;

    //Variables Barra de vida
    public int salud;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

     
    

    //Variables de reinicio
    public Vector3 initPosition;


    private void Awake()
    {
        inputCr = new InputSystem();
        //Andar
        inputCr.Movimiento.Andar.performed += ctx => movimiento = ctx.ReadValue<float>();
        inputCr.Movimiento.Andar.canceled += ctx => movimiento = 0;
        //Correr
        inputCr.Movimiento.Correr.started += _ => { correr = true; };
        inputCr.Movimiento.Correr.canceled += _ => { correr = false; };
        //Saltar
        inputCr.Movimiento.Saltar.started += _ => { saltar = true; };
        inputCr.Movimiento.Saltar.canceled += _ => { saltar = false; };


    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        speed = 1;
        maxSpeed = 4f;
        jumpForce = 2f;
        distanciaSuelo = 0.25f;

        salud = VariablesPublicas.saludCurrent;
        slider.value = salud;
        initPosition = gameObject.transform.position; 

    }

    // Update is called once per frame
    void Update()
    {
        salud = VariablesPublicas.saludCurrent;
        slider.value = salud;
        alive = VariablesPublicas.alive;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if (alive)
        {
            Saltar();
            Correr();
        }
        if(salud <=0)
        {
            Muerte();
            Invoke("Reinicio", 1.5f);
        }
        //print(movimiento);
     

    }
    private void FixedUpdate()
    {
        if (alive)
        {
            Andar();
            Giro(desplX);
        }
        
    }


    void Andar()
    {
        desplX = movimiento;
        rb2D.velocity = new Vector2(desplX* maxSpeed, rb2D.velocity.y);   //Mantener velocidad en el aire y moverse sin que afecte(Movimiento en el aire)
        speed = rb2D.velocity.x;
        speed = Mathf.Abs(speed);
        animator.SetFloat("Andar", speed);
    }

    void Saltar()//Script para que salte y la animacion cambie
    {
        if (saltar && animator.GetBool("IsGrounded"))//Animacion de saltar//Cojer datos del animator
        {
            rb2D.AddForce(new Vector2(0f, 1f) * jumpForce, ForceMode2D.Impulse);//Aplicamos fuerza para que pueda saltar
            animator.SetTrigger("Jump");//Cambio de animaciones
        }
     
        Debug.DrawRay(transform.position, Vector2.down * distanciaSuelo, Color.red); //Dibuja la linea de deteccion
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanciaSuelo);//Detecta si hay algo en su camino
        if (hit.collider != null)//Si el collider esta no hay nada //Animacion de cambio de caer a correr
        {
            animator.SetBool("IsGrounded", true);

        }
        else
        {
            animator.SetBool("IsGrounded", false);
        }
    }
    void Giro(float horizontal)//Scrip para que cambie de direccion dependiendo de a que direccion se mueva
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    void Correr()//Cuando haya animaciones descomentar y comprobar
    {
        speed = rb2D.velocity.x;
        if (correr && Mathf.Abs(speed) > 0)
        {
            animator.SetBool("Run", true);
            maxSpeed = 6.5f;
            
        }
        else 
        {
            animator.SetBool("Run", false);
            maxSpeed = 4f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            VariablesPublicas.saludCurrent = VariablesPublicas.saludCurrent - 20;
        }
    }
    void Muerte()
    {
        animator.SetTrigger("Muerte");
    }
    void Reinicio()
    {
        transform.position = initPosition;
        
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
