using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //Variables del input Sistem
    InputSystem inputCr;
    float movimiento;
    bool saltando;
    bool correr;
    bool saltar;
    
    [SerializeField] ParticleSystem humo;
    

    public float speed;
    [SerializeField] Rigidbody2D rb2D;
    Animator animator;

    //SEELCCIÓN DE SKIN
    //Booleana que indica que se está seleccionando
    bool selectingSkin = false;
    Vector2 selecSkinAxis;
    //Skin seleccionado: 0=> Sin ropa / 1=> Azul  / 2 => Amarillo/ 3 => Morado
    public int skinSelected = 0;
    int currentSkin; //Para diferenciar la actual de la nueva

    //Sprite con el menú de selección y array con las imágenes
    GameObject menuSkinParent;
    [SerializeField] Image menuSkinImage;
    [SerializeField] Sprite[] imagesSkin = new Sprite[4];

    //Animator Override
    [SerializeField] AnimatorOverrideController animatorOverride;
    //Array con las animaciones del Animator Override Controller (que lo toma del Animator "Sprite"
    string[] clipsNames = { "Andar", "Correr", "Damage", "Distancia", "Idle", "Meele", "Muerte", "Salto" };
    //Arrays con las animaciones correspondientes de cada skin
    [SerializeField] AnimationClip[] skinSinRopa = new AnimationClip[8];
    [SerializeField] AnimationClip[] skinMorado = new AnimationClip[8];
    [SerializeField] AnimationClip[] skinAzul = new AnimationClip[8];
    [SerializeField] AnimationClip[] skinAmarillo = new AnimationClip[8];
    //Array que cogerá los valore
    AnimationClip[] arraySkins = new AnimationClip[8];

    bool vivo;
    float desplX;
    float maxSpeed;
    float jumpForce;
    public bool facingRight = true;
    [SerializeField] float distanciaSuelo;

    //Variables Barra de vida
    public int salud;
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    bool muerto = false;
     
    

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
        //Abrir el menú de selección de skin
        inputCr.Movimiento.Skin.started += _ => { selectingSkin = true; };
        inputCr.Movimiento.Skin.canceled += _ => { selectingSkin = false; };
        //Ejes de selección de skin
        inputCr.Movimiento.SkinSelect.performed += ctx => selecSkinAxis = ctx.ReadValue<Vector2>();
        inputCr.Movimiento.SkinSelect.canceled += ctx => selecSkinAxis = Vector2.zero;

    }

    // Start is called before the first frame update
    void Start()
    {
        

        animator = GetComponentInChildren<Animator>();

        //Adjudica las animaciones
        animator.runtimeAnimatorController = animatorOverride;

        //Oculto el menú de selección de skin y asigno el básico
        menuSkinParent = GameObject.Find("SelectSkin");
        menuSkinParent.SetActive(false);
        

        UpdateSkins("sinRopa");
        menuSkinImage.sprite = imagesSkin[0];

        
        speed = 1;
        maxSpeed = 4f;
        jumpForce = 40f;
        distanciaSuelo = 0.25f;
        animator.SetBool("Muerto", false);

        salud = VariablesPublicas.saludCurrent;
        slider.value = salud;
        initPosition = gameObject.transform.position; 

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.paused || PauseManager.inventario)
            return;


        //print(vivo);
        salud = VariablesPublicas.saludCurrent;
        slider.value = salud;
        vivo = VariablesPublicas.alive;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        //Si estoy vivo y no estoy seleccionando personaje
        if (vivo)
        {
            Saltar();
            Correr();
            muerteCaida();
            SelectSkin();
        }

        if(salud <=0 && vivo)
        {
            Muerte();
            
            //Invoke("Reinicio", 1.5f);
        }
        //print(movimiento);
     

    }
    private void FixedUpdate()
    {
        if (vivo)
        {
            Andar();
            Giro(desplX);
        }
        
    }


    void Andar()
    {
        if (selectingSkin)
            return;

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
    public void Giro(float horizontal)//Scrip para que cambie de direccion dependiendo de a que direccion se mueva
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    void Correr()
    {
        speed = rb2D.velocity.x;
        if (correr && Mathf.Abs(speed) > 0)
        {
            animator.SetBool("Run", true);
            maxSpeed = 9f;
            
        }
        else 
        {
            animator.SetBool("Run", false);
            maxSpeed = 4f;
        }
    }

    public void TakeDamage(int damage)
    {
        if (vivo)
        {
            VariablesPublicas.saludCurrent = VariablesPublicas.saludCurrent - damage;
            animator.SetTrigger("Damage");
        }
       
    }
    public void CurarVida()
    {
        int vidaCurrar;
        vidaCurrar = VariablesPublicas.saludMax - VariablesPublicas.saludCurrent;
        VariablesPublicas.saludCurrent = VariablesPublicas.saludCurrent + vidaCurrar;
    }
    void Muerte()
    {
            StartCoroutine("Morir");
            print("me han  matado");
            animator.SetTrigger("Muerte");
            VariablesPublicas.alive = false;
         // Invoke("Reinicio", 2.5f);
            
            animator.SetBool("Muerto", true);
            
            


    }
    void Reinicio()
    {

        //Cambiar esto a escena de GameOver
        SceneManager.LoadScene(5);
        
        

    }
    IEnumerator Morir()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("GameOver");
        }

    }
    private void OnEnable()//Importantisimo para el funcionamiento del nuevo input system
    {
        inputCr.Enable();
    }

    void muerteCaida()
    {
        if(transform.position.y <= -10)
        {
            animator.SetTrigger("Muerte");
            VariablesPublicas.alive = false;
            Invoke("Reinicio", 2.5f);
            
            animator.SetBool("Muerto", true);
        }
    }
    private void OnDisable()//Importantisimo para el funcionamiento del nuevo input system
    {
        inputCr.Disable();
    }

    void SelectSkin()
    {
       
        //Interruptor para mostrar el menu, y para cuando soltamos el botón
        if (!menuSkinParent.activeSelf && selectingSkin)
        {
            currentSkin = skinSelected;
            menuSkinParent.SetActive(true);
        }
        else if(menuSkinParent.activeSelf && !selectingSkin)
        {
            print("Eligiendo: " + selectingSkin);
            //Asignamos el nuevo skin, si es diferente
            if(currentSkin != skinSelected)
            {
                switch (skinSelected)
                {

                    case 1:
                        UpdateSkins("azul");
                        break;
                    case 2:
                        UpdateSkins("amarillo");
                        break;
                    case 3:
                        UpdateSkins("morado");
                        break;
                    default:
                        UpdateSkins("");
                        break;
                }
            }
            //Ocultamos el menú
            menuSkinParent.SetActive(false);
            //Aquí deberíamos poner la bomba de humo
            humo.Play();
            

        }

        //Asignamos el personaje según el valor del eje
        if(selectingSkin)
        {
            print(selecSkinAxis);
            if(selecSkinAxis.y == 1 && skinSelected != 0)
            {
                skinSelected = 0;
                menuSkinImage.sprite = imagesSkin[0];
              
            }
            else if (selecSkinAxis.x == 1 && skinSelected != 1)
            {
                skinSelected = 1;
                menuSkinImage.sprite = imagesSkin[1];
                
            }
            else if (selecSkinAxis.y == -1 && skinSelected != 2)
            {
                skinSelected = 2;
                menuSkinImage.sprite = imagesSkin[2];
                
            }
            else if (selecSkinAxis.x == -1 && skinSelected != 3)
            {
                skinSelected = 3;
                menuSkinImage.sprite = imagesSkin[3];
                
            }
        }
    }

    void UpdateSkins(string color)
    {
        //Asignamos el array de skins que le corresponda
        //AnimationClip[] arraySkins;
        if (color == "morado")
            arraySkins = skinMorado;
        else if (color == "azul")
            arraySkins = skinAzul;
        else if (color == "amarillo")
            arraySkins = skinAmarillo;
        else 
            arraySkins = skinSinRopa;
        //Hacemos un bucle por los nombres
        int n = 0;
        foreach (string nombre in clipsNames)
        {
            print(nombre);
            animatorOverride[nombre] = arraySkins[n];
            n++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            transform.parent = collision.gameObject.transform;

        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent = null;

    }
}
